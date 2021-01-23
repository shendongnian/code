    static void CallingSoapFunction()
    {
         SoapClient proxy = new SoapClient("SoapEndPoint");
         var result = proxy.Add(7,2); // Proxy opens the channel, we invoke our method, we input our parameters.
         Console.WriteLine(result);
    }
