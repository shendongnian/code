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
    
                // modify the values.
    
                var json = jsonObject.ToString();
    
                Console.WriteLine(json);
            }
        }
    }
