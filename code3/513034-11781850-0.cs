    Private Sub WatchForDrives()
        Dim monitor As New DeviceStatusMonitor(DeviceClass.FileSystem, False)
        monitor.StartStatusMonitoring()
        AddHandler monitor.DeviceNotification, AddressOf MonitorDeviceNotified
    End Sub
    Private Sub MonitorDeviceNotified(ByVal sender As Object, ByVal e As DeviceNotificationArgs)
        Dim message As String = String.Format("Disk '{0}' has been {1}.", e.DeviceName, If(e.DeviceAttached, "inserted", "removed"))
        MessageBox.Show(message)
    End Sub
