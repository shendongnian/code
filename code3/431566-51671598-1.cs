     Dim _counter As Integer 
     Private Sub Control_MouseHover(ByVal sender As Object, ByVal e As EventArgs) _
     Handles Control.MouseHover
        ' Create a new Timer object.
		Dim timer As New Timer()
		' Set the timer's interval.
		timer.Interval = 1000
		' Create the Tick-listening event.
		AddHandler _timer.Tick, Sub(sender As Object, e As EventArgs)
			' Update the counter variable.
			_counter += 1
			' If the set time has reached, then show a MessageBox.
			If _counter = 3 Then
				MessageBox.Show("Three seconds have passed!")
			End If
		End Sub
		' Start the timer.
		_timer.Start()
    End Sub
