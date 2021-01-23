    Public Property CustomTextFormatter As String
		Get
			If itsCustomTextFormatter Is Nothing Then
				Return "Something"
			End If
			Return itsCustomTextFormatter
		End Get
		Set(ByVal value As String)
			itsCustomTextFormatter = value
		End Set
	End Property
