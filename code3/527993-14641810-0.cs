       class UserWithConstructor
        {
            public UserWithConstructor(int id, string name)
            {
                Ident = id;
                FullName = name;
            }
            public int Ident { get; set; }
            public string FullName { get; set; }
        }
