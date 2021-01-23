    Public Class Window
        Public Sub New()
            InitializeComponent()
            AddHandler TextBox.TextChanged, Sub(TBsender As Object, TBe As EventArgs)
                                                 CheckCode()
                                            End Sub
        End Sub
    End Class
