    Imports Microsoft.Win32
    Imports System.Runtime.InteropServices
    
    
    
    Public Class Form1
    
        <DllImport("wininet.dll")>
        Public Shared Function InternetSetOption(hInternet As IntPtr, dwOption As Integer, lpBuffer As IntPtr, dwBufferLength As Integer) As Boolean
        End Function
    
        Public Const INTERNET_OPTION_SETTINGS_CHANGED As Integer = 39
        Public Const INTERNET_OPTION_REFRESH As Integer = 37
    
    
        'This function is what is called after editing the registry - this causes internet explorer to update its proxy even if it is already open.
        'It also effects the web browser control in any VB.net application that is running.
        Public Sub globalProxy_apply()
            Dim settingsReturn As Boolean = False
            Dim refreshReturn As Boolean = False
            settingsReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0)
            If Not settingsReturn Then
                MessageBox.Show("Error 001: Line ""InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0)"" failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            refreshReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_REFRESH, IntPtr.Zero, 0)
            If Not refreshReturn Then
                MessageBox.Show("Error 002: Line ""InternetSetOption(IntPtr.Zero, INTERNET_OPTION_REFRESH, IntPtr.Zero, 0)"" failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Sub
    
        Public Function globalProxy_IsProxyEnabled() As Boolean
            Try
                Dim Regs As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Internet Settings", RegistryKeyPermissionCheck.ReadWriteSubTree)
                If Regs.GetValue("ProxyEnable") <> Nothing Then
                    If Regs.GetValue("ProxyEnable").ToString() = "0" Then
                        Return False
                    Else
                        Return True
                    End If
                Else
                    Return False
                End If
            Catch ex As Exception
                MessageBox.Show("Error 01X: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End Function
    
        Public Function globalProxy_GetProxyServer() As String
            Try
                Dim Regs As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Internet Settings", RegistryKeyPermissionCheck.ReadWriteSubTree)
                If Regs.GetValue("ProxyServer") <> Nothing Then
                    Return Regs.GetValue("ProxyServer").ToString()
                Else
                    Return ""
                End If
            Catch ex As Exception
                MessageBox.Show("Error 02X: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return ""
            End Try
        End Function
    
        Public Sub globalProxy_DisableProxy()
            Dim regkey As RegistryKey
            Try
                regkey = Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Internet Settings")
                regkey.SetValue("ProxyEnable", False, RegistryValueKind.DWord)
                regkey.Close()
            Catch ex As Exception
                MessageBox.Show("Error 03X: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
    
            globalProxy_apply()
        End Sub
    
        Public Sub globalProxy_SetProxy(ByVal ServerName As String)
            Dim regkey As RegistryKey
            Try
                regkey = Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Internet Settings")
                regkey.SetValue("ProxyServer", ServerName, RegistryValueKind.Unknown)
                regkey.SetValue("ProxyEnable", True, RegistryValueKind.DWord)
                regkey.Close()
            Catch ex As Exception
                MessageBox.Show("Error 04X: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
    
            globalProxy_apply()
        End Sub
    
        Private Sub B_Set_Click(sender As System.Object, e As System.EventArgs) Handles B_Set.Click
            If TextBox1.Text = "" Then
                globalProxy_DisableProxy()
            Else
                globalProxy_SetProxy(TextBox1.Text)
            End If
    
        End Sub
    
        Private Sub B_Disable_Click(sender As System.Object, e As System.EventArgs) Handles B_Disable.Click
            globalProxy_DisableProxy()
        End Sub
    
        Private Sub B_Get_Click(sender As System.Object, e As System.EventArgs) Handles B_Get.Click
            If globalProxy_IsProxyEnabled() Then
                TextBox1.Text = globalProxy_GetProxyServer()
            Else
                TextBox1.Text = ""
            End If
        End Sub
    
    End Class
