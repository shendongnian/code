	Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandlerTextBoxDouble(TextBox1)
    End Sub
    Public Sub AddHandlerTextBoxDouble(ByVal TextBoxMe As Object)
        Dim TextBox As New TextBox
        TextBox = CType(TextBoxMe, TextBox)
        AddHandler TextBox.KeyPress, AddressOf TextBox_KeyPress
        AddHandler TextBox.TextChanged, AddressOf TextBox_TextChanged
    End Sub
    Private Sub TextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ValidatingNumber(e, sender)
    End Sub
    Public Sub TextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim TextBox As New TextBox
        TextBox = CType(sender, TextBox)
        If Not IsNumeric(TextBox.Text) And TextBox.Text <> "." Then
            TextBox.Text = ""
        End If
    End Sub
    Public Sub ValidatingNumber(ByVal e As Object, ByVal control As Object)
        Try
            If CType(control, TextBox).Text.IndexOf(".") > -1 And e.KeyChar = "." Then
                e.KeyChar = ""
            End If
            If (Asc(e.KeyChar) < 58 And Asc(e.KeyChar) > 47) Or e.KeyChar = vbBack Or e.KeyChar = "." Then
                e.KeyChar = e.KeyChar
            Else
                e.KeyChar = ""
                Try
                    CType(e, System.Windows.Forms.KeyPressEventArgs).Handled = True
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
            MsgBox("ValidatingNumber")
        End Try
    End Sub
	End Class
