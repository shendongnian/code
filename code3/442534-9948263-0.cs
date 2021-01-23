	Private Sub Pre_Load()
		Dim sBasePath As String = AppDomain.CurrentDomain.BaseDirectory
		Dim sAllFiles() As String = Directory.GetFiles(sBasePath)
		For Each sAssemblyFile As String In sAllFiles
			If sAssemblyFile.EndsWith(".dll") Then
				If Not Me.HasThisAssembly(sAssemblyFile) Then
					Assembly.Load(AssemblyName.GetAssemblyName(sAssemblyFile))
				End If
			End If
		Next
	End Sub
	Private Function HasThisAssembly(ByVal vsAssemblyName As String) As Boolean
		For Each oAssembly As Assembly In AppDomain.CurrentDomain.GetAssemblies()
			Dim oFile As New FileInfo(vsAssemblyName)
			If oFile.Name = oAssembly.GetName().Name + ".dll" Then
				Return True
				Exit Function
			End If
		Next
		Return False
	End Function
