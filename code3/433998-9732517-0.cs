        public class Pro
        {
            // Auto-Impl Properties for trivial get and set
            public String Url { get; set; }
        }
        //Here accessing the property of Url
         Pro proUrl = new Pro();// // Intialize a new object.
         proUrl.Url = "www.google.com";//Setting the value
         Console.WriteLine("The url is {0}",proUrl.Url);
