     public class MyCustomClass
        {
            public string MyString1 { get; set; }
            public string MyString2 { get; set; }
            public string MyString3 { get; set; }
        }
    
        class MyApp
        {
            public MyApp()
            {
                List<MyCustomClass> customList = new List<MyCustomClass>();
                customList.Add(new MyCustomClass
                {
                    MyString1 = "Hello",
                    MyString2 = "Every",
                    MyString3 = "Body",
                });
            }
        }
