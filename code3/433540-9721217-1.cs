    ' Declare your process object with WithEvents, so that events can be handled.
    Dim WithEvents MyProcess As Process
    Dim MyProcessIsRunning As Boolean
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' start the process. this is an example.
        MyProcess = Process.Start("Notepad.exe")
        ' enable raising events for the process.
        MyProcess.EnableRaisingEvents = True
        ' set the flag to know whether my process is running
        MyProcessIsRunning = True
    End Sub
    Private Sub MyProcess_Exited(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyProcess.Exited
        ' the process has just exited. what do you want to do?
        MyProcessIsRunning = False
        MessageBox.Show("The process has exited!")
    End Sub
