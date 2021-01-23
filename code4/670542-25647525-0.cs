    Imports System.ComponentModel
    Public Class CTextBox
    Inherits TextBox
    Dim _zUseEnterAsTab As Boolean = True
    Dim _zUseTransparent As Boolean = False
    Dim _zUseTransparentColor As Color = Color.Transparent
    Dim _zUseTransparentBorderColor As Color = Color.Gray
    <Description("Use the Enter Key as Tab (Stops Beeps) only for Single line TextBox"), Category("CTextBox")> _
    Public Property zUseEnterAsTab() As Boolean
        Get
            Return _zUseEnterAsTab
        End Get
        Set(value As Boolean)
            _zUseEnterAsTab = value
            Me.Invalidate()
        End Set
    End Property
    <Description("Use Transparent TextBox"), Category("CTextBox")> _
        Public Property zUseTransparent() As Boolean
        Get
            Return _zUseTransparent
        End Get
        Set(value As Boolean)
            _zUseTransparent = value
            Me.Invalidate()
        End Set
    End Property
    <Description("Change the transparency to ANY color or shade or Alpha"), Category("CTextBox")> _
    Public Property zUseTransparentColor() As Color
        Get
            Return _zUseTransparentColor
        End Get
        Set(value As Color)
            _zUseTransparentColor = value
            Me.Invalidate()
        End Set
    End Property
    <Description("Border color of the texbox when transparency used"), Category("CTextBox")> _
        Public Property zUseTransparentBorderColor() As Color
        Get
            Return _zUseTransparentBorderColor
        End Get
        Set(value As Color)
            _zUseTransparentBorderColor = value
            Me.Invalidate()
        End Set
    End Property
    Protected Overrides Sub InitLayout()
        'Again for my benifit - there may be other ways to force the transparency 
        'code at form / event startup, but this is the way i chose, any advice
        'or alternatives would be great!! :)
        If Not DesignMode Then
            'Basically don't do in design mode!
            If _zUseTransparent Then
                CreateMyLabel(Me)
                MakeLabelVisible(foundLabel, Me)
            End If
        End If
        MyBase.InitLayout()
    End Sub
    Protected Overrides Sub OnKeyPress(e As KeyPressEventArgs)
        If MyBase.Multiline = True Then
            MyBase.OnKeyPress(e)
        Else
            If e.KeyChar = Chr(Keys.Enter) Then
                e.Handled = True
                If zUseEnterAsTab = True Then SendKeys.Send("{tab}")
                MyBase.OnKeyPress(e)
            End If
        End If
    End Sub
    Protected Overrides Sub OnLeave(e As EventArgs)
        If _zUseTransparent Then
            CreateMyLabel(Me)
            MakeLabelVisible(foundLabel, Me)
        End If
        MyBase.OnLeave(e)
    End Sub
    Protected Overrides Sub OnEnter(e As EventArgs)
        If _zUseTransparent Then
            CreateMyLabel(Me)
            MakeTextBoxVisible(foundLabel, Me)
        End If
        MyBase.OnEnter(e)
    End Sub
    Dim foundLabel As CLabel = Nothing
    Sub CreateMyLabel(_TxtBox As CTextBox)
        foundLabel = Nothing
        Dim l As CLabel
        If GetMyLabel("L_" & Me.Name, Me) Then
            l = foundLabel
            If Not l.Name = "L_" & Me.Name Then
                MsgBox("L_" & Me.Name)
            End If
            l.Font = _TxtBox.Font
            l.Text = _TxtBox.Text
            l.BorderColor = _zUseTransparentBorderColor
            l.BackColor = _zUseTransparentColor
            l.BorderStyle = Windows.Forms.BorderStyle.None 'Handled by paint event
        Else
            l = New CLabel
            l.Name = "L_" & _TxtBox.Name
            l.BorderColor = _zUseTransparentBorderColor
            l.BackColor = _zUseTransparentColor
            l.Size = _TxtBox.Size
            l.BorderStyle = Windows.Forms.BorderStyle.None 'Handled by paint event
            l.AutoSize = False
            l.Font = _TxtBox.Font
            l.Location = _TxtBox.Location
            l.Text = _TxtBox.Text
            l.Anchor = _TxtBox.Anchor
            _TxtBox.Parent.Controls.Add(l)
            foundLabel = l
        End If
    End Sub
    Function GetMyLabel(_LabelName As String, _TxtBox As CTextBox) As Boolean
        For Each ctl As Control In _TxtBox.Parent.Controls
            If ctl.Name = _LabelName Then
                foundLabel = ctl
                Return True
            End If
        Next
        Return False
    End Function
    Private Sub MakeLabelVisible(_Label As CLabel, _TxtBox As CTextBox)
        _Label.Location = _TxtBox.Location
        _Label.Anchor = _TxtBox.Anchor
        _Label.Size = _TxtBox.Size
        _TxtBox.Size = New Size(0, 0)
        _TxtBox.Anchor = AnchorStyles.None
    End Sub
    Private Sub MakeTextBoxVisible(_Label As CLabel, _TxtBox As CTextBox)
        _TxtBox.Location = _Label.Location
        _TxtBox.Anchor = _Label.Anchor
        _TxtBox.Size = _Label.Size
        _Label.Size = New Size(0, 0)
        _Label.Anchor = AnchorStyles.None
    End Sub
    End Class
    Public Class CLabel
    Inherits Label
    Public BorderColor As Color = Color.Gray
    Sub New()
        MyBase.FlatStyle = Windows.Forms.FlatStyle.Standard
        'Added padding as labels shifted text upwards
        'NOT tested on all fonts etc, purely for my sources
        MyBase.Padding = New Padding(0, 3, 0, 0)
    End Sub
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        Dim _TxtBox As CTextBox = Nothing
        Dim _TxtBoxName As String = Microsoft.VisualBasic.Right(Me.Name, Len(Me.Name) - 2)
        For Each elem As Control In Me.Parent.Controls
            If elem.Name = _TxtBoxName Then
                _TxtBox = elem
                Exit For
            End If
        Next
        _TxtBox.Select()
        MyBase.OnMouseDown(e)
    End Sub
    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        Cursor = Cursors.IBeam
        MyBase.OnMouseEnter(e)
    End Sub
    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        Cursor = Cursors.Default
        MyBase.OnMouseLeave(e)
    End Sub
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        ControlPaint.DrawBorder(e.Graphics, Me.DisplayRectangle, Color.Gray, ButtonBorderStyle.Solid)
    End Sub
    Private Sub MakeLabelVisible(_Label As CLabel, _TxtBox As CTextBox)
        _Label.Size = _TxtBox.Size
        _TxtBox.Size = New Size(0, 0)
        _Label.Anchor = _TxtBox.Anchor
        _TxtBox.Anchor = AnchorStyles.None
    End Sub
    Private Sub MakeTextBoxVisible(_Label As CLabel, _TxtBox As CTextBox)
        _TxtBox.Size = _Label.Size
        _Label.Size = New Size(0, 0)
        _TxtBox.Anchor = _Label.Anchor
        _TxtBox.Anchor = AnchorStyles.None
    End Sub
    End Class
