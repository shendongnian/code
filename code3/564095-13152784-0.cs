    Imports System.Text
    Imports Microsoft.VisualStudio.TestTools.UnitTesting
    Imports System.Reactive.Linq
    Imports System.Reactive
    Imports System.Reactive.Subjects
    Imports FluentAssertions
    
    
    
    Class Concentrator
        Implements IObservable(Of Boolean)
    
        Private Property Dict As Dictionary(Of IObservable(Of Boolean), Boolean) = New Dictionary(Of IObservable(Of Boolean), Boolean)
    
        Public Function RegisterSource(observable As IObservable(Of Boolean)) As IDisposable
            Dict.Add(observable, False)
            Dim d = observable.Subscribe(
                Sub(value)
                    Dict(observable) = value
                    Fire()
                End Sub)
            Return Disposables.Disposable.Create(
                Sub()
                    d.Dispose()
                    Dict.Remove(observable)
                    Fire()
                End Sub)
        End Function
    
        Private _Subject As Subject(Of Boolean) = New Subject(Of Boolean)
    
        Private Sub Fire()
            _Subject.OnNext(Dict.Values.All(Function(x) x))
        End Sub
    
        Public Function Subscribe(observer As IObserver(Of Boolean)) As IDisposable Implements IObservable(Of Boolean).Subscribe
            Return _Subject.Subscribe(observer)
        End Function
    End Class
    
    <TestClass()> Public Class UnitTest2
    
        <TestMethod()> Public Sub TestMethod1()
            Dim s0 = New BehaviorSubject(Of Boolean)(False)
            Dim s1 = New BehaviorSubject(Of Boolean)(False)
    
            Dim l As Boolean
    
            Dim c = New Concentrator
    
            Dim r0 = c.RegisterSource(s0)
            Dim r1 = c.RegisterSource(s1)
    
            Dim s = c.Subscribe(Sub(v) l = v)
    
            l.Should.Be(False)
    
            s0.OnNext(True)
            l.Should.Be(False)
    
            s1.OnNext(True)
            l.Should.Be(True)
    
            s0.OnNext(False)
            l.Should.Be(False)
    
            ' Remove one of the message sources should update
            ' the result
            r0.Dispose()
            l.Should.Be(True)
    
        End Sub
    
    End Class
