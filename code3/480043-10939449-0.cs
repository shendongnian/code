    using System;
    using System.IO;
    
    namespace csharp_station.howto
    {
        class TextFileReader
        {
            static void Main(string[] args)
            {
                TextReader tr1 = new StreamReader("file1.txt");
                TextReader tr2 = new StreamReader("file2.txt");
                TextWriter tw = new StreamWriter("result.txt");
    
                int count1 = Convert.ToInt32(tr1.ReadLine());
                int count2 = Convert.ToInt32(tr2.ReadLine());
                tw.WriteLine(count1 + count2);
    
                for(int i = 0; i < count1; i++)
                {
                    tw.WriteLine(tr1.ReadLine());
                }
    
                for(int i = 0; i < count2; i++)
                {
                    tw.WriteLine(tr2.ReadLine());
                }
    
                tr1.Close();
                tr2.Close();
                tw.Close();
            }
        }
    }
