    Public Class Chainer(Of R)
        Public ReadOnly Result As R
        Private Sub New(Result As R)
            Me.Result = Result
        End Sub
        Public Shared Function Create() As Chainer(Of R)
            Return New Chainer(Of R)(Nothing)
        End Function
        Public Function Chain(Of S)(Method As Func(Of S)) As Chainer(Of S)
            Return New Chainer(Of S)(Method())
        End Function
        Public Function Chain(Of S)(Method As Func(Of R, S)) As Chainer(Of S)
            Return New Chainer(Of S)(If(Result Is Nothing, Nothing, Method(Result)))
        End Function
    End Class
