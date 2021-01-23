    using System;
    using Independentsoft.Office;
    using Independentsoft.Office.Word;
    using Independentsoft.Office.Word.Tables;
    
    namespace Sample
    {
        class Program
        {
            static void Main(string[] args)
            {
                WordDocument doc = new WordDocument("c:\\test.docx");
    
                Table[] tables = doc.GetTables();
    
                foreach (Table table in tables)
                {
                    //read data
                }
    
            }
        }
    }
