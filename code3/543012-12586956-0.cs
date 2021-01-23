		If CObj(publicProperties) IsNot Nothing AndAlso publicProperties.Any() Then
			Return publicProperties.All(Function(p)
					'check not self-references... 
				Dim left = p.GetValue(Me, Nothing)
				Dim right = p.GetValue(other, Nothing)
				If GetType(TValueObject).IsAssignableFrom(left.GetType()) Then
					Return Object.ReferenceEquals(left, right)
				Else
					Return left.Equals(right)
				End If
			End Function)
		End If
