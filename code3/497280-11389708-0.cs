    List<Customer> query = from c in db.Customers select c;
            foreach (var q in query)
            {
                Type type = typeof(Customer);
                PropertyInfo[] properties = type.GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    string value = property.GetValue(type, null) != null
                        ? property.GetValue(type, null).ToString() 
                        : string.Empty; // or whatever you want the default text to be
                    csv.Append(q.id).Append(delimiter);
                }
            }
