    public List<UserData> GetData(int clientNo)
    {
        var theResults = new List<UserData>();
        var connStr = "serverstring";
        using (SqlConnection cnn = new SqlConnection(connStr))
        {
            cnn.Open();
            using (
                SqlCommand cmd =
                    new SqlCommand(
                        "SELECT [Name], [PaternalLastName], [MaternalLastName] FROM [SocioInfo] Where ([SocioNum] = @SocioNum)",
                        cnn))
            {
                cmd.Parameters.AddWithValue("@SocioNum", txtInput.Text);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    theResults.Add(new UserData
                        {
                            Name = rdr.GetString(0),
                            LastName = rdr.GetString(1),
                            Maternal = rdr.GetString(2)
                        });
                }
            }
        }
        return theResults;
    }
     public class UserData
            {
                public string Name { get; set; }
                public string LastName { get; set; }
                public string Maternal { get; set; }
            }
