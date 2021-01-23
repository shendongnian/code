    using System;
    using Microsoft.Office.Interop.Word;
    using System.IO;
    using System.Reflection;
    namespace WordFormattingFindReplace {
        class Program {
            static void Main(string[] args) {
            }
            public static string searchDoc(string fileName) {
                _Application word = new Application(); ;
                _Document doc;
                string folderName = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(folderName,fileName);
                doc = word.Documents.Open(filePath);
                var find=doc.Range().Find;
                find.Text="Hello";
                find.Format=true;
                find.Replacement.Font.Name="Tahoma";
                find.Replacement.Font.ColorIndex=WdColorIndex.wdRed;
                find.Execute(Replace:WdReplace.wdReplaceAll) {};
                doc.SaveAs2(Path.Combine(folderName,"New",fileName));
                doc.Close();
                //We need to cast this to _Application to resolve which Quit method is being called
                ((_Application)word.Application).Quit();
                return fileName;
            }
        }
    }
