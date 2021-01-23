         private void enter_button_Click(object sender, EventArgs e)
         {
            var first = fname.Text; 
            var last = lname.Text;
            var addy = address.Text;
            var city1 = city.Text;
            var stat = state.Text;
            var zippy = zip.Text;
    
            Validate(fname);
            Validate(lname);
            Validate(city);
            Validate(state);
            exValidate(address);
            numValidate(zip);
    
            using (var conn = new SqlConnection("Data Source=TX-MANAGER;Initial Catalog=Contacts;Integrated Security=True"))
            using (var cmd = new SqlCommand(@"INSERT INTO Contacts ([First], [Last], [Address], [City], [State], [ZIP]) VALUES (@first, @last, @addy, @city1, @stat, @zippy)", conn))
            {
                cmd.Parameters.AddRange(
                    new[]
                        {
                            new SqlParameter(@"first", SqlDbType.VarChar).Value = first,
                            new SqlParameter(@"last", SqlDbType.VarChar).Value = last,
                            new SqlParameter(@"addy", SqlDbType.VarChar).Value = addy,
                            new SqlParameter(@"city1", SqlDbType.VarChar).Value = city1,
                            new SqlParameter(@"state", SqlDbType.VarChar).Value = stat,
                            new SqlParameter(@"zippy", SqlDbType.SmallInt).Value = zippy
                        });
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
