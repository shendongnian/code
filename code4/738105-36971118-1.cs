    Private Sub setRegisterForWebBrowser()
        Dim appName = Process.GetCurrentProcess().ProcessName + ".exe"
        SetIE8KeyforWebBrowserControl(appName)
    End Sub
    Private Sub SetIE8KeyforWebBrowserControl(appName As String)
        'ref:    http://stackoverflow.com/questions/17922308/use-latest-version-of-ie-in-webbrowser-control
        Dim Regkey As RegistryKey = Nothing
        Dim lgValue As Long = 8000
        Dim strValue As Long = lgValue.ToString()
        Try
            'For 64 bit Machine 
            If (Environment.Is64BitOperatingSystem) Then
                Regkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION", True)
            Else  'For 32 bit Machine 
                Regkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION", True)
            End If
            'If the path Is Not correct Or 
            'If user't have priviledges to access registry 
            If (Regkey Is Nothing) Then
                MessageBox.Show("Application Settings Failed - Address Not found")
                Return
            End If
            Dim FindAppkey As String = Convert.ToString(Regkey.GetValue(appName))
            'Check if key Is already present 
            If (FindAppkey = strValue) Then
                MessageBox.Show("Required Application Settings Present")
                Regkey.Close()
                Return
            End If
            'If key Is Not present add the key , Kev value 8000-Decimal 
            If (String.IsNullOrEmpty(FindAppkey)) Then
                ' Regkey.SetValue(appName, BitConverter.GetBytes(&H1F40), RegistryValueKind.DWord)
                Regkey.SetValue(appName, lgValue, RegistryValueKind.DWord)
                'check for the key after adding 
                FindAppkey = Convert.ToString(Regkey.GetValue(appName))
            End If
            If (FindAppkey = strValue) Then
                MessageBox.Show("Registre de l'application appliquée avec succès")
            Else
                MessageBox.Show("Échec du paramètrage du registre, Ref: " + FindAppkey)
            End If
        Catch ex As Exception
            MessageBox.Show("Application Settings Failed")
            MessageBox.Show(ex.Message)
        Finally
            'Close the Registry 
            If (Not Regkey Is Nothing) Then
                Regkey.Close()
            End If
        End Try
    End Sub
