    Public Shared ReadOnly IsSpinningProperty As DependencyProperty =
        DependencyProperty.Register("IsSpinning",
                                    GetType(Boolean),
                                    GetType(MyCode))
    
    Public Property IsSpinning() As Boolean
        Get
            Return CBool(GetValue(IsSpinningProperty))
        End Get
        Set(ByVal value As Boolean)
            SetValue(IsSpinningProperty, value)
        End Set
    End Property
