    Dim _progressForm As frmLoading
    
        Private Sub frmMain_Load(sender As System.Object, e As System.EventArgs) Handles Me.Load
            'start loading on a separate thread
            BackgroundWorker1.RunWorkerAsync()
            'show a marquee animation while loading
            _progressForm = New frmLoading
            _progressForm.ShowDialog(Me)
        End Sub
    
        Private Sub BackgroundWorker1_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
            'simulate a long load
            For i As Integer = 1 To 10
                System.Threading.Thread.Sleep(1000)
            Next
        End Sub
    
        Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
            _progressForm.Close()
        End Sub
