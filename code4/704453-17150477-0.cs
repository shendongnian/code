        public List<Users> FindUsers()
        {
            List<Users> users = new List<Users>();
            executeCmd("SELECT REF(Users) FROM Users c");
            while (Reader.Read())
            {
                MtObject obj = Reader.GetObject(0);
                users.Add(new Users(db, obj.MtOid));
            }
            Reader.Close();
            return users;
        }
