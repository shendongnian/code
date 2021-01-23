    Public Module MyWinFormsApp
    
        Public Sub Main()
            MyWpfApp.App.EnsureApplicationResources()
            Application.Run(New frmWinFormsMain())
            System.Windows.Application.Current.Shutdown()
        End Sub
    End Module
