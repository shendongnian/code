    Private Sub WatchForDrives()
    	Dim monitor As New DeviceStatusMonitor(DeviceClass.FileSystem, False)
    	monitor.StartStatusMonitoring()
    	monitor.DeviceNotification += Function(sender As Object, e As DeviceNotificationArgs) Do
    		Dim message As String = String.Format("Disk '{0}' has been {1}.", e.DeviceName, If(e.DeviceAttached, "inserted", "removed"))
    		MessageBox.Show(message, "Disk Status")
    	End Function
    End Sub
