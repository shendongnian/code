    using System;
    using System.Data;
    using System.Data.OleDb;
    
    class Program
    {
     static void Main()
     {
       OleDbDataReader reader = OleDbEnumerator.GetRootEnumerator();
    
       DisplayData(reader);
    
       Console.WriteLine("Press any key to continue.");
       Console.ReadKey();
     }
    
     static void DisplayData(OleDbDataReader reader)
     {
       while (reader.Read())
       {
         for (int i = 0; i < reader.FieldCount; i++)
         {
           Console.WriteLine("{0} = {1}",
            reader.GetName(i), reader.GetValue(i));
         }
         Console.WriteLine("==================================");
       }
     }
    }
