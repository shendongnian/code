    Private Sub BackgroundWorkerMaster_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorkerMaster.DoWork
        Do While bgwChild1.IsBusy AndAlso bgwChild2.IsBusy
            'wait
        Loop
    End Sub
