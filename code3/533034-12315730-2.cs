    Public Class SomeClass
        Public Event MyEvent(ByVal sender As Object, ByVal e As EventArgs)
        // The following sub is the empty delegate
        Private Sub Handler(ByVal sender As Object, ByVal e As EventArgs) _
                            Handles Me.MyEvent
            // empty
        End Sub
    End Class
