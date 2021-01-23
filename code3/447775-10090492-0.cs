    using System;
    using System.IO;
    class Test 
    {
        public static void Main() 
        {
            string path = @"c:\temp\MyTest.txt";
            string path2 = path + "temp";
    
            try 
            {
                // Create the file and clean up handles.
                using (FileStream fs = File.Create(path)) {}
    
                // Ensure that the target does not exist.
                File.Delete(path2);
    
                // Copy the file.
                File.Copy(path, path2);
                Console.WriteLine("{0} copied to {1}", path, path2);
    
                // Try to copy the same file again, which should succeed.
                File.Copy(path, path2, true);
                Console.WriteLine("The second Copy operation succeeded, which was expected.");
            } 
    
            catch 
            {
                Console.WriteLine("Double copy is not allowed, which was not expected.");
            }
        }
    }
