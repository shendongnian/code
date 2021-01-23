    using Excel = Microsoft.Office.Interop.Excel;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                Excel.Application app = new Excel.Application();
                Excel.Workbook wk = app.Workbooks.Open(@"D:\testExcel.xlsx");
                Excel.Worksheet sh = (Excel.Worksheet)wk.ActiveSheet;
                
                Excel.Range rng = sh.get_Range("A1", "Z20");
                Console.WriteLine(CountWord(rng, "a"));
    
                wk.Close(false);
                app.Quit();
    
                Console.ReadLine();
            }
            
            private static int CountWord(Excel.Range rng, string word)
            {
                int i = 0;
    
                Excel.Range rng1 = rng.Find(word);
    
                if (rng1 != null)
                    i++;
                else
                    return 0;
    
                string address = rng1.Address;
                
                Console.WriteLine(address);
    
                while (true)
                {
                    rng1 = rng.FindNext(rng1);
    
                    if (rng1 == null)
                        return i;
    
                    Console.WriteLine(rng1.Address);
    
                    if (rng1.Address == address)
                        return i;
                    else
                        i++;            
                }
            }
        }
    }
