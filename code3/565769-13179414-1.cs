            foreach(T item in data)
            {
                var props = item.GetType().GetProperties();
                foreach(var prop in props)
                {   
                    dataString += prop.GetValue(item, null);
                }
            }
