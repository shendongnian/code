     Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button7.Click
        con = New MySqlConnection("Database=;" & _
                                "Data Source=;" & _
                                "User Id=;Password=;")
        con.Open()
        Try
            Query = "SELECT Email FROM users WHERE Email='bee@gmail.com'"
            cmd = New MySqlCommand(Query, con)
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                MessageBox.Show("Email taken")
                '  While reader.Read
                'MysqlData.Text = MysqlData.Text & reader.Item("Email")
                ' End While
            Else
                MessageBox.Show("Email does not exist")
            End If
        Catch ex As Exception
           
        End Try
      
    End Sub
