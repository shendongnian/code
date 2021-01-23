    class MyConsole
    {
       public static void WriteLine(string msg)
       {
          Console.Write(String.Format("{0} {1}", DateTime.Now, msg));
       }
    }
