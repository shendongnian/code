            //test settings...
            var a = System.Configuration.ConfigurationManager.AppSettings["myAppKey"];
            if (a == null)
            {
                Console.WriteLine("Application key does not exists!");
            }
            var b = System.Configuration.ConfigurationManager.ConnectionStrings["myConName"];
            if (b == null)
            {
                Console.WriteLine("Connection does not exists!");
            }
