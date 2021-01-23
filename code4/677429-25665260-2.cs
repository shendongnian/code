    Imports System.Deployment.Application.ApplicationDeployment
    Imports System.Reflection
    Imports System.IO
    Imports Microsoft.Win32
    Module ControlPanelIcon
        ' Call this method as soon as possible
        ' Writes entry to registry
        Public Function SetAddRemoveProgramsIcon() As Boolean
            Dim iName As String = "iconFile.ico" ' <---- set this (1)
            Dim aName As String = "appName" '      <---- set this (2)
            Try
                Dim iconSourcePath As String = Path.Combine(System.Windows.Forms.Application.StartupPath, iName)
                If Not IsNetworkDeployed Then Return False ' ClickOnce check
                If Not CurrentDeployment.IsFirstRun Then Return False
                If Not File.Exists(iconSourcePath) Then Return False
                Dim myUninstallKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Uninstall")
                Dim mySubKeyNames As String() = myUninstallKey.GetSubKeyNames()
                For i As Integer = 0 To mySubKeyNames.Length Step 1
                    Dim myKey As RegistryKey = myUninstallKey.OpenSubKey(mySubKeyNames(i), True)
                    Dim myValue As Object = myKey.GetValue("DisplayName")
                    If (myValue IsNot Nothing And myValue.ToString() = aName) Then
                        myKey.SetValue("DisplayIcon", iconSourcePath)
                        Return True
                    End If
                Next i
            Catch ex As Exception
                Return False
            End Try
            Return False
        End Function
    End Module
