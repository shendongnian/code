    Public Sub iTunesApplication_Dispose()
        RemoveHandler iTunesApplication.OnPlayerPlayEvent, AddressOf Track_Played
        Runtime.InteropServices.Marshal.ReleaseComObject(iTunesApplication)
        iTunesApplication = Nothing
        System.GC.Collect()
    End Sub
