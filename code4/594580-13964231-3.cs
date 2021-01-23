    Imports System.ComponentModel
    
    <CLSCompliant(True)>
    Public Class Progressbar
        Inherits Control
    
        <CLSCompliant(True),
        RefreshProperties(RefreshProperties.Repaint),
        Browsable(True),
        Category("Appearance"),
        DefaultValue(100)>
        Public Property Maximum As Integer
            Get
                Return _maximum
            End Get
            Set(value As Integer)
                _maximum = value
                Me.Invalidate()
            End Set
        End Property
        <CLSCompliant(True),
        RefreshProperties(RefreshProperties.Repaint),
        Browsable(True),
        Category("Appearance"),
        DefaultValue(0)>
        Public Property Value As Integer
            Get
                Return _value
            End Get
            Set(value As Integer)
                _value = value
                Me.Invalidate()
            End Set
        End Property
        <CLSCompliant(True),
        RefreshProperties(RefreshProperties.Repaint),
        Browsable(True),
        Category("Appearance"),
        DefaultValue(CStr(Nothing))>
        Public Property ProgressbarImage As Image
            Get
                Return _progressbarImage
            End Get
            Set(value As Image)
                _progressbarImage = value
                Me.Invalidate()
            End Set
        End Property
        <CLSCompliant(True),
        RefreshProperties(RefreshProperties.Repaint),
        Browsable(True),
        Category("Appearance"),
        DefaultValue(GetType(Color), "DarkGray")>
        Public Property ProgressbarColor As Color
            Get
                Return _progressbarColor
            End Get
            Set(value As Color)
                _progressbarColor = value
                Me.Invalidate()
            End Set
        End Property
    
        Private _maximum As Integer = 100
        Private _value As Integer = 0
        Private _progressbarImage As Image = Nothing
        Private _progressbarColor As Color = Color.DarkGray
    
        Sub New()
    
            InitializeComponent()
    
            SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
    
        End Sub
        Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
    
            Dim g As Graphics = e.Graphics
            Dim r As Rectangle = Me.ClientRectangle
    
            ControlPaint.DrawBorder(g, r, Color.Black, ButtonBorderStyle.Solid)
    
            r.Inflate(-1, -1)
            r.Width = CInt(r.Width * _value / _maximum) - 1
            If r.Width < 1 Then Return
    
            If _progressbarImage Is Nothing Then
                Using b As New SolidBrush(_progressbarColor)
                    g.FillRectangle(b, r)
                End Using
            Else
                g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                g.DrawImage(_progressbarImage, r)
            End If
    
        End Sub
    
    End Class
