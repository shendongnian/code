    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using HDMClient.hdssWS;
    namespace HDMClient
    {
    class Program
    {
        static void Main(string[] args)
        {
            HDMClient.hdssWS.StockQuoteServicePortTypeClient client = new hdssWS.StockQuoteServicePortTypeClient("StockQuoteServiceHttpSoap11Endpoint");
            client.update("apple", 1232); 
      
            string [] result = client.getPrice("apple", 12);
            for (int i = 0; i < result.Length; i++) 
            {
                Console.WriteLine(result[i]);
            }
        }
    }
    }
