    class MyClass
    {
        private Dictionary<String,User> _userLookup;
        public MyClass()
        {
            _userLookup = Context.Users.ToDictionary(u => u.UserName.ToLower());
        }
        private User getUserByName(String name)
        {
            var lowerName = name.ToLower();
            return _userLookup.ContainsKey(lowerName) ? _userLookup[lowerName] : null;
        }     
    }
