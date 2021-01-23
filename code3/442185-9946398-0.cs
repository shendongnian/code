        Dim retval As Object = Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\TimeZoneInformation", "DynamicDaylightTimeDisabled", 0)
        If retval IsNot Nothing Then
            Select Case CInt(retval)
                Case 0
                    Trace.WriteLine("Automatically adjust clock for Daylight Saving Time is checked")
                Case 1
                    Trace.WriteLine("Automatically adjust clock for Daylight Saving Time is NOT checked")
            End Select
        End If
 
