    Imports System.Reactive
    Imports System.Reactive.Concurrency
    Imports System.Reactive.Disposables
    Imports System.Reactive.Linq
    <Extension()>
    Public Function AtLeastEvery(Of T)(source As IObservable(Of T), 
                                       timeout As TimeSpan, 
                                       defaultValue As T, 
                                       scheduler As IScheduler
                                      ) As IObservable(Of T)
        If source Is Nothing Then Throw New ArgumentNullException("source")
        If scheduler Is Nothing Then Throw New ArgumentNullException("scheduler")
        Return Observable.Create(
            Function(observer As IObserver(Of T))
                Dim id As ULong
                Dim gate As New Object()
                Dim timer As New SerialDisposable()
                Dim lastValue As T = defaultValue
                Dim createTimer As Action =
                    Sub()
                        Dim startId As ULong = id
                        timer.Disposable = scheduler.Schedule(timeout,
                                               Sub(self As Action(Of TimeSpan))
                                                   Dim noChange As Boolean
                                                   SyncLock gate
                                                       noChange = (id = startId)
                                                       If noChange Then
                                                           observer.OnNext(lastValue)
                                                       End If
                                                   End SyncLock
                                                   'only restart if no change, otherwise
                                                   'the change restarted the timeout
                                                   If noChange Then self(timeout)
                                               End Sub)
                    End Sub
                'start the first timeout
                createTimer()
                'subscribe to the source observable
                Dim subscription = source.Subscribe(
                    Sub(v)
                        SyncLock gate
                            id += 1UL
                            lastValue = v
                        End SyncLock
                        observer.OnNext(v)
                        createTimer() 'reset the timeout
                    End Sub,
                    Sub(ex)
                        SyncLock gate
                            id += 1UL
                        End SyncLock
                        observer.OnError(ex)
                        'do not reset the timeout, because the sequence has ended
                    End Sub,
                    Sub()
                        SyncLock gate
                            id += 1UL
                        End SyncLock
                        observer.OnCompleted()
                        'do not reset the timeout, because the sequence has ended
                    End Sub)
                Return New CompositeDisposable(timer, subscription)
            End Function)
    End Function
