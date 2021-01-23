    Private _lineWidth As Single = 2.0F
    <Browsable(True), Editor(GetType(UpDownValueEditor), GetType(UITypeEditor)), DefaultValue(2.0F)> _
    Public Property RectangleLineWidth As Single
            Get
                UpDownValueEditor.udControl.DecimalPlaces = 0
                UpDownValueEditor.udControl.Increment = 1
                UpDownValueEditor.udControl.Minimum = 0
                UpDownValueEditor.udControl.Maximum = 20
                UpDownValueEditor.valueType = "Single"
                Return Me._lineWidth
            End Get
            Set(ByVal value As Single)
                Me._lineWidth = value
            End Set
    End Property
