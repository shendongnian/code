        string ConnectionString;
        switch (comboBox1.SelectedIndex)
        {
            case 0:
                ConnectionString = "Data Source=server1;Initial Catalog=database1;User ID=user1;Password=password1";
                break;
            case 1:
                ConnectionString = "Data Source=server2;Initial Catalog=database2;User ID=user1;Password=password2";
                break;
            case 3:
                ConnectionString = "Data Source=server3;Initial Catalog=database3;User ID=user1;Password=password3";
                break;
        }
        SqlConnection Con = new SqlConnection(ConnectionString);
        Con.Open();
