    Private Sub VideoCamera_Initialized(sender As Object, eventArgs As Object)
	If Initialized IsNot Nothing Then
		Initialized.Invoke(Me, New EventArgs())
	End If
    End Sub
    
    Public Property LampEnabled() As Boolean
	Get
		Return CBool(_videoCameraLampEnabledPropertyInfo.GetGetMethod().Invoke(_videoCamera, New Object(-1) {}))
	End Get
	Set
		_videoCameraLampEnabledPropertyInfo.GetSetMethod().Invoke(_videoCamera, New Object() {value})
	End Set
    End Property
