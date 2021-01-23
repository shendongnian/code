     using System;
     using System.Text;
     using System.IO;
 
     namespace FileWriting_SW
     {
      class Program
      {
        class FileWrite
        {
            public void WriteData()
            {
                FileStream fs = new FileStream("c:\\test.txt", FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                Console.WriteLine("Enter the text which you want to write to the file");
                string str = Console.ReadLine();
                sw.WriteLine(str);
                sw.Flush();
                sw.Close();
                fs.Close();
            }
          }
           static void Main(string[] args)
           {
               FileWrite wr = new FileWrite();
               wr.WriteData();
           }
           }
        }
 
