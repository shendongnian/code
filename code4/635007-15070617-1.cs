    private string GetRoomName_BasedOn_RoomNumber(string roomNumber, MyConnection connection) {
        using (var command = connection.CreateCommand())
        {
             command.CommandText = ("Select Room_name from firstfloor where Room_no=(?room)");
             command.Parameters.AddWithValue("?room", a);
             command.ExecuteNonQuery();
             object response = command.ExecuteScalar();
             return response as string; // consider <null> as a "No such Room Number" signal
        }
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        string a = label1.Text;
        string b = label2.Text;
        string connString = "Server=Localhost;Database=this;Uid=root;password=root";
        using (var connection = new MySqlConnection(connString))
        {
           button1.Text = this.GetRoomName_BasedOn_RoomNumber(a, connection);
           button2.Text = this.GetRoomName_BasedOn_RoomNumber(b, connection);
        }
    }
