	Public Event ContentScaleChanged As EventHandler
	Private Sub invoke()
		If otherXXX.ContentScaleChanged IsNot Nothing Then
			otherXXX.ContentScaleChanged(c, EventArgs.Empty)
		End If
	End Sub
