    Private Shared InputTypeProperty As DependencyProperty = DependencyProperty.Register("InputType", GetType(MyInputType), GetType(MyTextBox))
    Public Property InputType As MyInputType
        Get
            Return GetValue(InputTypeProperty)
        End Get
        Set(value As MyInputType)
            SetValue(InputTypeProperty, value)
        End Set
    End Property
