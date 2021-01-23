    Protected Sub BackupProgressDelegate(sender as Object, e as BackupEventArgs)
        Debug.WriteLine(e.Percentage.ToString())
    End Sub
    ...
    AddHandler bu.BackupProgress, AddressOf BackupProgressDelegate
