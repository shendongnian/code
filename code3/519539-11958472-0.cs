		''' <summary>
		''' Search and Find Registry Function
		''' </summary>
		Public Shared Function SearchRegistry(ByVal dllName As String) As String
			'Open the HKEY_CLASSES_ROOT\CLSID which contains the list of all registered COM files (.ocx,.dll, .ax) 
			'on the system no matters if is 32 or 64 bits.
			Dim t_clsidKey As RegistryKey = Registry.ClassesRoot.OpenSubKey("CLSID")
			'Get all the sub keys it contains, wich are the generated GUID of each COM.
			For Each subKey In t_clsidKey.GetSubKeyNames.ToList
				'For each CLSID\GUID key we get the InProcServer32 sub-key .
				Dim t_clsidSubKey As RegistryKey = Registry.ClassesRoot.OpenSubKey("CLSID\" & subKey & "\InProcServer32")
				If Not t_clsidSubKey Is Nothing Then
					'in the case InProcServer32 exist we get the default value wich contains the path of the COM file.
					Dim t_valueName As String = (From value In t_clsidSubKey.GetValueNames() Where value = "")(0).ToString
					'Now gets the value.
					Dim t_value As String = t_clsidSubKey.GetValue(t_valueName).ToString
					'And finaly if the value ends with the name of the dll (include .dll) we return it
					If t_value.EndsWith(dllName) Then
						Return t_value
					End If
				End If
			Next
			'if not exist, return nothing
			Return Nothing
		End Function
