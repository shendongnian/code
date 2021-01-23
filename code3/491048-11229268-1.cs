    using System;
    using System.IO;
    class Test 
    {
      public static void Main() 
      {
         try 
         {
            // Create an instance of StreamReader to read from a file.
            // The using statement also closes the StreamReader.
            using (StreamReader sr = new StreamReader("TestFile.txt")) 
            {
                String line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = sr.ReadLine()) != null) 
                {
                    String Chunk1 = line.Substring( 0, 10);  // First 10
                    String Chunk2 = line.Substring(10, 10);  // Second 10
                    String Chunk3 = line.Substring(20, 10);  // Third 10
                    String Chunk4 = line.Substring(30, 17);  // Now 17
                    String Chunk5 = line.Substring(47);      // Remainder (correction: Chunk2 --> Chunk5)
                    Console.WriteLine("Chunks 1: {0} 2: {1} 3: {2} 4: {3} 5: {4})",
                         Chunk1, Chunk2, Chunk3, Chunk4, Chunk5);
               
                }
                Console.ReadLine();
            }
         }
         catch (Exception e) 
         {
            // Let the user know what went wrong.
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
         }
      }
    }
