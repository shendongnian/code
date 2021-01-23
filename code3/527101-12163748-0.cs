    public class RepresentativeUser
    {
        public string UserName { get; set; }
        public string Pasword { get; set; }
        //etc
        public int IsManager { get; set; }
    }
    public void InsertRepresentativeUser(RepresentativeUser representativeUser)
    {
        const string query = @"INSERT INTO representative_dev.representative_users
                            (Username, Password, 
                            IsManager) 
                        VALUES (@Username, @Password,
                                @IsManager);
                        select count(*) from representative_dev.representative_users";
        var count = DbConnection.Query<decimal>(query,
            new
            {
                representativeUser.UserName,
                representativeUser.Pasword,
                representativeUser.IsManager
            });
    }
