	Protected Sub MoveGridViewRows(sender As Object, e As EventArgs)
		Dim btnUp As Button = DirectCast(sender, Button)
		Dim row As GridViewRow = DirectCast(btnUp.NamingContainer, GridViewRow)
		' Get all items except the one selected      
		Dim rows = GridView1.Rows.Cast(Of GridViewRow)().Where(Function(a) a <> row).ToList()
		Select Case btnUp.CommandName
			Case "Up"
				'If First Item, insert at end (rotating positions)              
				If row.RowIndex.Equals(0) Then
					rows.Add(row)
				Else
					rows.Insert(row.RowIndex - 1, row)
				End If
				Exit Select
			Case "Down"
				'If Last Item, insert at beginning (rotating positions)
				If row.RowIndex.Equals(GridView1.Rows.Count - 1) Then
					rows.Insert(0, row)
				Else
					rows.Insert(row.RowIndex + 1, row)
				End If
				Exit Select
		End Select
		GridView1.DataSource = rows.[Select](Function(a) New With { _
			Key .FirstName = DirectCast(a.FindControl("txtFirstName"), TextBox).Text, _
			Key .LastName = DirectCast(a.FindControl("txtLastName"), TextBox).Text _
		}).ToList()
		GridView1.DataBind()
	End Sub
