    string MyConString = "SERVER=localhost;" +
        "DATABASE=database;" +
        "UID=root;" +
        "PASSWORD=pass;";
    System.IO.FileStream fs = new FileStream(@"D:\link\to\image.png", FileMode.Open);
    System.IO.BufferedStream bf = new BufferedStream(fs);
    byte[] buffer = new byte[bf.Length];
    bf.Read(buffer, 0, buffer.Length);    
    byte[] buffer_new = buffer;
    MySqlConnection connection = new MySqlConnection(MyConString);
    connection.Open();
    MySqlCommand command = new MySqlCommand("", connection);
    command.CommandText = "insert into table(fldImage) values(@image);";
    command.Parameters.AddWithValue("@image", buffer_new);
    command.ExecuteNonQuery();
    connection.Close();
    Console.WriteLine("Task Performed!");
    Console.ReadLine();
