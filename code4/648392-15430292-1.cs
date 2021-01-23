        // GET api/xxx/username
        [ActionName("username")]
        public User GetUserByUsername(string username)
        {
            var user = db.Users.FirstOrDefault(s => s.Username == username);
            if (user == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return user;
        }
