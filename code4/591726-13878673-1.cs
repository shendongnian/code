    var proxy = System.Net.WebRequest.DefaultWebProxy  as  System.Net.IWebProxy;
        if (proxy != null)
        {
            Console.WriteLine("Yes");
        }
