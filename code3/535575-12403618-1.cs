    Imports System
    Imports System.Text
    Imports System.IO
    Imports System.Diagnostics
    Imports System.Threading
    Imports System.ComponentModel
    Imports Microsoft.VisualBasic
    
    Imports System.Collections.Generic
    Imports System.Linq
    
    
    Imports System.Collections
    
    
    
    
    Public Class Form3
    
        ' Define static variables shared by class methods.
        Private Shared shellOutput As StringBuilder = Nothing
        Private Shared numOutputLines As Integer = 0
        Private Shared stdIN As StreamWriter
        Private Shared p As New FixedProcess 'as new
        Private Shared oldOutlineData As String = ""
        Private Shared PasswordInput As Boolean = False
    
    
    
        Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
            ShowISDNStatus()
          
        End Sub
    
        Public Sub ShowISDNStatus()
            Dim p_info As New ProcessStartInfo 'as new
            p_info.FileName = Form1.PlinkPath
            p_info.Arguments = Form1.KommandoArguments
            p_info.UseShellExecute = False
            p_info.CreateNoWindow = True
            p_info.RedirectStandardOutput = True
            p_info.RedirectStandardInput = True
            p_info.RedirectStandardError = True
            ' Set our event handler to asynchronously read the shell output.
            AddHandler p.OutputDataReceived, AddressOf dirOutputHandler
            AddHandler p.ErrorDataReceived, AddressOf dirOutputHandler
    
    
    
            shellOutput = New StringBuilder
            p.StartInfo = p_info
            p.Start()
            p.BeginOutputReadLine()
            p.BeginErrorReadLine()
            stdIN = p.StandardInput
    
            'stdIN.WriteLine("enable" & vbCr & "K#limdor1" & vbCrLf)
            'Timer1.Enabled = True
            'System.Threading.Thread.Sleep(500)
    
            'stdIN.WriteLine("term len 0")
            'stdIN.WriteLine("show isdn status")
    
            stdIN.WriteLine("enable" & vbCr & Form1.TextPassword.Text & vbCrLf)
            Timer1.Enabled = True
            System.Threading.Thread.Sleep(500)
            Me.TextBox2.Text = ""
            stdIN.WriteLine("term len 0")
            stdIN.WriteLine("show isdn status")
            Me.TextBox1.Select(TextBox1.Text.Length, 0)
            Me.TextBox1.ScrollToCaret()
    
        End Sub
    
        Private Shared Sub dirOutputHandler(ByVal sendingProcess As Object, ByVal outLine As DataReceivedEventArgs)
            ''If Not String.IsNullOrEmpty(outLine.Data) Then
            shellOutput.Append(outLine.Data)
    
            'For i = 1 To Len(outLine.Data)
            '    FormDebug.TextBox1.Text = "Len von OutlineData: " & Len(outLine.Data) & " " & Asc(Mid(outLine.Data, i, 1)) & "---" & Mid(outLine.Data, i, 1)
            'Next
    
            If outLine.Data = "Store key in cache? (y/n) " Then
                stdIN.WriteLine("y")
            End If
    
            Form3.TextBox1.Text = outLine.Data
    
            ''End If
        End Sub
    
        Private Sub Form3_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    
    
    
        End Sub
    
        Private Sub Form3_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
    
    
            p.Kill()
            
    
    
        End Sub
    
    
        Private Sub TextBox2_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles TextBox2.PreviewKeyDown
    
            If e.KeyCode = Keys.Return Then
    
                If PasswordInput = False Then
                    If Me.TextBox2.Text = "en" Then
                        Me.TextBox2.UseSystemPasswordChar = True
                        Me.TextBox2.Text = ""
                        PasswordInput = True
                        Timer1.Enabled = False
                        Me.TextBox1.AppendText("Password:")
    
                    ElseIf Me.TextBox2.Text = "ena" Then
                        Me.TextBox2.UseSystemPasswordChar = True
                        Me.TextBox2.Text = ""
                        PasswordInput = True
                        Timer1.Enabled = False
                        Me.TextBox1.AppendText("Password:")
    
                    ElseIf Me.TextBox2.Text = "enab" Then
                        Me.TextBox2.UseSystemPasswordChar = True
                        Me.TextBox2.Text = ""
                        PasswordInput = True
                        Timer1.Enabled = False
                        Me.TextBox1.AppendText("Password:")
    
                    ElseIf Me.TextBox2.Text = "enabl" Then
                        Me.TextBox2.UseSystemPasswordChar = True
                        Me.TextBox2.Text = ""
                        PasswordInput = True
                        Timer1.Enabled = False
                        Me.TextBox1.AppendText("Password:")
    
                    ElseIf Me.TextBox2.Text = "enable" Then
                        Me.TextBox2.UseSystemPasswordChar = True
                        Me.TextBox2.Text = ""
                        PasswordInput = True
                        Timer1.Enabled = False
                        Me.TextBox1.AppendText("Password:")
    
                    ElseIf Me.TextBox2.Text = "" Then
                        stdIN.WriteLine()
                        System.Threading.Thread.Sleep(500)
                        Me.TextBox1.Select(TextBox1.Text.Length, 0)
                        Me.TextBox1.ScrollToCaret()
                    Else
                        stdIN.WriteLine(Me.TextBox2.Text)
                        System.Threading.Thread.Sleep(500)
                        Me.TextBox2.Text = ""
                        Me.TextBox1.Text = shellOutput.ToString
                        Me.TextBox1.Select(TextBox1.Text.Length, 0)
                        Me.TextBox1.ScrollToCaret()
                    End If
    
                Else
    
                    stdIN.WriteLine("enable" & vbCr & Me.TextBox2.Text & vbCrLf)
                    System.Threading.Thread.Sleep(500)
                    Me.TextBox2.Text = ""
                    Timer1.Enabled = True
                    Me.TextBox2.UseSystemPasswordChar = False
                    stdIN.WriteLine("term len 0")
                    Me.TextBox1.Select(TextBox1.Text.Length, 0)
                    Me.TextBox1.ScrollToCaret()
                    PasswordInput = False
    
                End If
    
    
            End If
    
        End Sub
    
    
        Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
    
        End Sub
    
        Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
            Me.TextBox1.SelectAll()
            Me.TextBox1.ScrollToCaret()
        End Sub
    
        Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
            ' If Me.TextBox1.Text <> shellOutput.ToString Then Me.TextBox1.Text = shellOutput.ToString
            Me.TextBox1.Text = shellOutput.ToString
    
        End Sub
    
        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    
            FormDebug.Show()
            'Dim frm As New Form3
            'Static Num As Integer
    
            'Num = Num + 1
            'frm.Text = "Copy of Form3 - " & Num
            'frm.Show()
        End Sub
    End Class
