    using System;
    
    class Parent
    {
      private Client m_client;
      public Parent()
      {
        m_client = new Client();
        Console.WriteLine("client inited");
      }
    }
    
    class Client: Parent
    {
      public Client()
      {
        //..
      }
    }
    
    class Test
    {
      public static void Main(string[] args)
      {
        Client c = new Client();
        Console.WriteLine("End");
      }
    }
