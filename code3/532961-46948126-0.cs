    	Public Class ReferencingObjectConverter : Inherits JsonConverter
			Private _objects As New HashSet(Of String)
			Private _ignoreNext As Boolean = False
			Public Overrides Function CanConvert(objectType As Type) As Boolean
				If Not _ignoreNext Then
					Return GetType(IElement).IsAssignableFrom(objectType) AndAlso Not GetType(IdProperty).IsAssignableFrom(objectType)
				Else
					_ignoreNext = False
					Return False
				End If
			End Function
			Public Overrides Sub WriteJson(writer As JsonWriter, value As Object, serializer As JsonSerializer)
				Try
					If _objects.Contains(CType(value, IElement).Id.Value) Then 'insert a reference to existing serialized object
						serializer.Serialize(writer, New Reference With {.Reference = CType(value, IElement).Id.Value})
					Else 'add to my list of processed objects
						_objects.Add(CType(value, IElement).Id.Value)
						'the serialize will trigger a call to CanConvert (which is how we got here it the first place)
						'and will bring us right back here with the same 'value' parameter (and SO eventually), so flag
						'the CanConvert function to skip the next call.
						_ignoreNext = True
						serializer.Serialize(writer, value)
					End If
				Catch ex As Exception
					Trace.WriteLine(ex.ToString)
				End Try
			End Sub
			Public Overrides Function ReadJson(reader As JsonReader, objectType As Type, existingValue As Object, serializer As JsonSerializer) As Object
				Throw New NotImplementedException()
			End Function
			Private Class Reference
				Public Property Reference As String
			End Class
		End Class
