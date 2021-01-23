    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            ''create connection 
            Dim conn As SqlConnection = New SqlConnection()
            conn.Open()
    
            Dim comm As SqlCommand = New SqlCommand()
            comm.Connection = conn
    
            ''insert data to sql database row by row
            Dim sr, name, email, tel_no As String
            For i As Integer = 0 To Me.DataGridView1.Rows.Count
                sr= Me.DataGridView1.Rows(i).Cells(0).Value.ToString()
                name= Me.DataGridView1.Rows(i).Cells(1).Value.ToString()
                email= Me.DataGridView1.Rows(i).Cells(2).Value.ToString()
                tel_no= Me.DataGridView1.Rows(i).Cells(3).Value.ToString()
    
                comm.CommandText = "insert into datagrid (sr, name, email, tel_no)
                values('" & sr& "','" & name& "','" & email& "','" & tel_no& "')"
                comm.ExecuteNonQuery()
            Next    
            conn.Close()
    
        End Sub
