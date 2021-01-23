        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using Word = Microsoft.Office.Interop.Word;
        using System.Reflection;
        using System.IO;
  
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
             
                Word._Application application = new Word.Application();
                object fileformat = Word.WdSaveFormat.wdFormatXMLDocument;
                DirectoryInfo directory = new DirectoryInfo(@"D:\abc");
                foreach (FileInfo file in directory.GetFiles("*.doc", SearchOption.AllDirectories))
                {
                    if (file.Extension.ToLower() == ".doc")
                    {
                        object filename = file.FullName;
                        object newfilename = file.FullName.ToLower().Replace(".doc", ".docx");
                        Word._Document document = application.Documents.Open(filename);
                        document.Convert();
                        document.SaveAs(newfilename, fileformat);
                        document.Close();
                        document = null;
                    }
                }
                application.Quit();
                application = null;
                 
            }
        }
    }
