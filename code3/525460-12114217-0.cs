            int content = 5;  //set for sake of program;
            int? test = null;
            if (content == 5)
            {
                test = content;
            }
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into TABLE (columnNameforTest) values ( @test)";
            cmd.Parameters.AddWithValue("@test", test);
            SqlConnection con = new SqlConnection("yourconnectionstring");
            int i = cmd.ExecuteNonQuery();
