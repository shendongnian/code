        public Dictionary<string, object> ExtractParameterNameAndValue<T>(List<T> colleciton)
            where T : class
        {
            var result = new Dictionary<string, object>();
            // out of the loop - generate getters
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var getterList = new List<Func<T,object>>();
            foreach (var p in properties)
            {
                getterList.Add(MyStatic.BuildUntypedGetter<T>(p));
            }
            // Array of getters
            var getters = getterList.ToArray(); // improving performance (?) - never use Dictionary
            // Corresponding array of Names
            var names = properties.Select(p => p.Name).ToArray();
            // iterate all data
            int counter = 0;
            foreach (var item in colleciton)
            {
                for (int i = 0; i< getters.Length; i++)
                {
                    var name = names[i]; // name from property
                    var value = getters[i](item);  // value from getter-call
                    result.Add(counter + " " + name, value); 
                }
                counter++;
            }
            return result; ;
        }
