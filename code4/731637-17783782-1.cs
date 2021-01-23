    <System.Runtime.CompilerServices.Extension()> _
		Public Sub AddRow(dr As DataRowCollection, ByRef objTypeConversion As List(Of Type), objValue As Object())
			Dim length = objTypeConversion.Count
			If length <> objValue.Length Then
				Throw New Exception("Data Types must be provided for all Values")
			End If
			Dim _n As Integer = 0
			objTypeConversion.ForEach(Function(t)
										  If t IsNot Nothing Then
											  Try
												  Dim converter = TypeDescriptor.GetConverter(t)
												  If converter IsNot Nothing Then
													  objValue(_n) = CTypeDynamic(converter.ConvertFrom(objValue(_n)), t)
												  End If
											  Catch ex As Exception
												  objValue(_n) = DBNull.Value
											  End Try
										  End If
										  _n = _n + 1
									  End Function)
			'Logic to convert into provided datatype
			dr.Add(objValue)
		End Sub
