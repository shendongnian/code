    public class Profile
    {
        public int Id {get;}
        public string Name {get; private set;}
        public Image Picture {get; private set;}
    
        public void Save()
        {
            using (var connection = new SqlConnection("myconnectionstring"))
            using (var command = new SqlCommand("", connection))
            {
                command.CommandText =
                    "UPDATE dbo.TblProfile " +
                    "SET " +
                        "Name = @name, " +
                        "Picture = @picture " +
                    "WHERE ID = @id";
                command.Parameters.AddWithValue("@name", Name);
                command.Parameters.AddWithValue("@picture", Picture);
                command.Parameters.AddWithValue("@id", Id);
                command.ExecuteNonQuery();
            }
        }
    }
