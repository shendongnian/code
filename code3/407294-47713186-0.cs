	Public Shared Function GetFirstVisualChild(Of T As DependencyObject)(depObj As DependencyObject) As T
		If (depObj IsNot Nothing) Then
			Dim i As Integer
			For i = 0 To VisualTreeHelper.GetChildrenCount(depObj) - 1
				Dim child As DependencyObject = VisualTreeHelper.GetChild(depObj, i)
				If (child IsNot Nothing AndAlso TypeOf child Is T) Then
					Return CType(child, T)
				End If
				Dim childItem As T = GetFirstVisualChild(Of T)(child)
				If (childItem IsNot Nothing) Then Return childItem
			Next
		End If
		Return Nothing
	End Function
