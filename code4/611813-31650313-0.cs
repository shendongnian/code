            Dim path = New ManagementPath With {.NamespacePath = "root\cimv2",
                                              .Server = "<REMOTE HOST OR IP>"}
        Dim scope = New ManagementScope(path)
        Dim condition = "DriveLetter = 'C:'"
        Dim selectedProperties = {"FreeSpace"}
        Dim query = New SelectQuery("Win32_Volume", condition, selectedProperties)
        Dim searcher = New ManagementObjectSearcher(scope, query)
        Dim results = searcher.Get()
        Dim volume = results.Cast(Of ManagementObject).SingleOrDefault()
        If volume IsNot Nothing Then
            Dim freeSpace As ULong = volume.GetPropertyValue("FreeSpace")
        End If
