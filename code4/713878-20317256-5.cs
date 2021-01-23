    static void Main(string[] args){
      OPC_client opcTest = new OPC_client(new bool[]{true, false});
      Console.WriteLine("Testing if message appears if value stays the same");
      opcTest.ItemActive[0] = true;
      Console.WriteLine();
      Console.WriteLine("Testing if message appears if value changes");
      opcTest.ItemActive[0] = false;
      Console.ReadLine();
    }
