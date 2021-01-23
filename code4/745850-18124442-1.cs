    namespace JsonEncryptionTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var obj = new
                    {
                        To = "Some name",
                        Subject = "A Subject",
                        Content = "A content"
                    };
    
                var jsonObject = JObject.FromObject(obj);
    
                // modify the values. Just doing something here to amuse you.
               var property = jsonObject.Property("Content");
               var value = (string) property.Value;
               property.Value = value.ToLower();
    
                var json = jsonObject.ToString();
    
                Console.WriteLine(json);
            }
        }
    }
