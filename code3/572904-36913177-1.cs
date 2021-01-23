     Dim rk1 As RegistryKey = Microsoft.Win32.RegistryKey.OpenBaseKey _
                                        (Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Registry64)
            Dim rk2 As RegistryKey = Microsoft.Win32.RegistryKey.OpenBaseKey _
                                        (Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Registry64)
            Dim rk3 As RegistryKey = Microsoft.Win32.RegistryKey.OpenBaseKey _
                                        (Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Registry64)
        rk1 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
        regpath = "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"
        rk2 = rk1.OpenSubKey(regpath)
        For Each subk As String In rk2.GetSubKeyNames
            rk3 = rk2.OpenSubKey(subk, False)
            value = rk3.GetValue("DisplayName", "")
            If value <> "" Then
                includes = True
                If value.IndexOf("Hotfix") <> -1 Then includes = False
                If value.IndexOf("Security Update") <> -1 Then includes = False
                If value.IndexOf("Update for") <> -1 Then includes = False
                If value.IndexOf("Service Pack") <> -1 Then includes = False
                For vAtual = 0 To UBound(Softwares)
                    If value = Softwares(vAtual) Then
                        includes = False
                    End If
                Next
                If includes = True Then
                    gridSoft.Rows.Add(value, rk3.GetValue("InstallDate", ""), rk3.GetValue("UninstallString", ""), rk3.GetValue("EstimatedSize", ""), rk3.GetValue("InstallLocation", ""), rk3.GetValue("Publisher", ""))
                    Softwares(vCont) = value
                    vCont = vCont + 1
                End If
            End If
        Next
