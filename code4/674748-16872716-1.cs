    Private Sub Form5_Load(sender As Object, e As EventArgs)
    		Me.panel1.AllowDrop = True
    		For Each c As Control In Me.panel1.Controls
    			c.MouseDown += New MouseEventHandler(AddressOf c_MouseDown)
    		Next
    		Me.panel1.DragOver += New DragEventHandler(AddressOf panel1_DragOver)
    		Me.panel1.DragDrop += New DragEventHandler(AddressOf panel1_DragDrop)
    	End Sub
    
    	Private Sub c_MouseDown(sender As Object, e As MouseEventArgs)
    		Dim c As Control = TryCast(sender, Control)
    		c.DoDragDrop(c, DragDropEffects.Move)
    	End Sub
    
    	Private Sub panel1_DragDrop(sender As Object, e As DragEventArgs)
    		Dim c As Control = TryCast(e.Data.GetData(e.Data.GetFormats()(0)), Control)
    		If c IsNot Nothing Then
    			c.Location = Me.panel1.PointToClient(New Point(e.X, e.Y))
    			Me.panel1.Controls.Add(c)
    		End If
    	End Sub
    
    	Private Sub panel1_DragOver(sender As Object, e As DragEventArgs)
    		e.Effect = DragDropEffects.Move
    	End Sub
