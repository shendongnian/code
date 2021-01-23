    Private Sub VideoCamera_Initialized(sender As Object, eventArgs As Object)
        RaiseEvent Initialized(Me, EventArgs.Empty)
    End Sub
    
    Public Property LampEnabled() As Boolean
        Get
            Return CBool(_videoCameraLampEnabledPropertyInfo.GetGetMethod().Invoke(_videoCamera, New Object() {}))
        End Get
        Set(value As Boolean)
            _videoCameraLampEnabledPropertyInfo.GetSetMethod().Invoke(_videoCamera, New Object() {value})
        End Set
    End Property
