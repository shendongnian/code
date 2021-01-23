        public User GetSingleUser(string userID = "me")
        {
            if(userID == "") throw new ArgumentException("UserID cannot be blank");
            string url = "{baseUrl}/users/{userID}?{opt_fields}".FormatWith(
                new { baseUrl = BASE_URL, userID = userID, opt_fields = "opt_fields=id,name,email,workspaces,workspaces.id,workspaces.name" });
            return (User)ParseJson<User>(AsanaRequest.GetResponse(url));
        }
        public User[] GetAllUsers()
        {
            string url = "{baseUrl}/users?{opt_fields}".FormatWith(
                new { baseUrl = BASE_URL, opt_fields = "opt_fields=id,name,email,workspaces,workspaces.id,workspaces.name" });
            return (User[])ParseJsonArray<User>(AsanaRequest.GetResponse(url));
        }
        public T ParseJson<T>(string json) where T : Parsable, new()
        {
            JSONNode root = JSON.Parse(json)["data"];
            T ret = new T();
            ret.Parse(root);
            return ret;
        }
        public T[] ParseJsonArray<T>(string json) where T : Parsable, new()
        {
            JSONArray root = JSON.Parse(json)["data"].AsArray;
            T[] nodes = new T[root.Count];
            for(int i = 0; i < root.Count; i++)
            {
                T newParsable = new T();
                newParsable.Parse(root[i]);
                nodes[i] = newParsable;
            }
            return nodes;
        }
