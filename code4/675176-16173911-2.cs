        public static dynamic ConvertToExpando(object obj)
        {
            IDictionary<string, object> expando = new ExpandoObject();
                foreach(var pi in obj.GetType().GetProperties())
                {
                    // there doesn't seem to be a way to know if it is an anonymous type directly. So I use IsPublic here.
                    if (pi.PropertyType.IsPublic)
                    {
                        expando[pi.Name] = pi.GetValue(obj);                    
                    }
                    else
                    {
                        expando[pi.Name] = ConvertToExpando(pi.GetValue(obj));
                    }
                }
            return expando;
        }
