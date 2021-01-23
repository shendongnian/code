        public async Task<T> GetData<T>(T dataObject)
        {
            var typeName = typeof(T).Name;
            switch (typeName)
            {
                case "PersonalInfo":
                    return await Task<T>.Factory.StartNew(() =>
                    {
                        return (T)(object)new PersonalInfo
                        {
                            FirstName = "Mickey",
                            LastName = "Mouse",
                            Adres = new Address { Country = "DLRP" },
                        };
                    });
            }
            return default(T);
        }   
