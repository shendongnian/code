    Imports System.Deployment.Application.ApplicationDeployment
    Imports System.Reflection
    Imports System.IO
    Imports Microsoft.Win32
    Module ControlPanelIcon
        ' Call this method as soon as possible
        ' Writes entry to registry
        Public Function SetAddRemoveProgramsIcon() As Boolean
            ' Only execute on a first run after first install or after update
            If IsNetworkDeployed And CurrentDeployment.IsFirstRun Then
                Try
                    '-----------------------------------------------
                    REM: (1) Specify icon file in the following line
                    '-----------------------------------------------
                    Dim iconSourcePath As String = Path.Combine(System.Windows.Forms.Application.StartupPath, "Logo.ico") '<-- the icon file
                    If (Not File.Exists(iconSourcePath)) Then Return False
                    Dim myUninstallKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Uninstall")
                    Dim mySubKeyNames As String() = myUninstallKey.GetSubKeyNames()
                    For i As Integer = 0 To mySubKeyNames.Length Step 1
                        Dim myKey As RegistryKey = myUninstallKey.OpenSubKey(mySubKeyNames(i), True)
                        Dim myValue As Object = myKey.GetValue("DisplayName")
                        '-------------------------------------------------
                        REM: (2) Specify application in the following line
                        '-------------------------------------------------
                        If (myValue IsNot Nothing And myValue.ToString() = "MyAppName") Then '<--- name of the application program
                            myKey.SetValue("DisplayIcon", iconSourcePath)
                            Exit For
                        End If
                    Next i
                Catch ex As Exception
                    Return False
                End Try
            End If
            Return True
        End Function
    End Module
