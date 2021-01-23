        public bool CheckUsername(string user_txt)
        {
            bool Result;
            Result = DataAccessLayer.ExecuteReader(user_txt);
            return Result;
        }
