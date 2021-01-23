    Private Sub BackgroundWorkerMaster_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorkerMaster.DoWork
        Do While bgwChild1.IsBusy AndAlso bgwChild2.IsBusy
            System.Threading.Thread.Sleep(1) 'wait for a small amount of time
        Loop
    End Sub
