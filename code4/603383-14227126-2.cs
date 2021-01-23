        public List<UserEntity> GetUserData(string username)
        {
            var q = _tableContext.CreateQuery<StoredUserEntity>(_tableName);
            return
                q.ToList().Select(x => new UserEntity {UserName = x.PartitionKey, Email = x.Email, Name = x.Name}).Where(x => x.UserName == username).ToList();
        }
