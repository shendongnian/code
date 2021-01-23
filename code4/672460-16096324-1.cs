    public static class ProductExtension
    {
        public static IEnumerable<Product> Union(this IEnumerable<Product> store1, IEnumerable<Product> store2)
        {
            List<Product> List = new List<Product>();
            foreach (var item in store2)
            {
                if (store1.Any(n=>n.Equals(item)))
                {
                    var obj = store1.First(n => n.Equals(item));
                    foreach (System.Reflection.PropertyInfo pi in obj.GetType().GetProperties())
                    {
                        object v1 = pi.GetValue(obj, null);
                        object v2 = pi.GetValue(item, null);
                        var value = v1;
                        if (v2 != null && (v1 == null || v1.ToString() == string.Empty) && v1 != v2)
                        {
                            value = v2;
                        }
                        pi.SetValue(obj, value, null);
                    }
                    List.Add(obj);
                }
                else {
                    List.Add(item);
                }            
            }
            
            foreach (var item in store1) { 
                if(!store2.Any(n=>n.Equals(item))){
                    List.Add(item);
                }
            }
            return List.AsEnumerable();
        }
    }
