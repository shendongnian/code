    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplicationExcelCeldas
    {
        class Program
        { 
            private const int NumberPositionColumnF = 6;
    
            static void Main(string[] args)
            {
                Microsoft.Office.Interop.Excel.Worksheet worksheet = new Microsoft.Office.Interop.Excel.Worksheet();
    
                var i = 0;
                var test = new TestExcel();
                do
                {
                    i++;
                    var rangeF = worksheet.get_Range(string.Format("F{0}" , i));
                    if (rangeF.Count == 0)
                    {
                        break;
                    }
    
                    var values = test.GetCellsStringArray(rangeF);
                    if (values.Count() > 0) 
                    {
                        int number = 0;
                        if (int.TryParse(values[0], out number))
                        {
                            var rangeAll = worksheet.get_Range(
                                string.Format("A{0}" , i), 
                                string.Format("{0}{1}", test.ColumnLetter(Program.NumberPositionColumnF + (number * 4)), i));
    
    
                            /*
                             your code for work with rangeAll
                            */
                        }
                    }
                    
                } while (true);
            }
        }
    
        class TestExcel
        {
            internal string[] GetCellsStringArray(Microsoft.Office.Interop.Excel.Range range)
            {
                var myvalues = (System.Array)range.Cells.Value;
                return this.ConvertToStringArray(myvalues);
            }
    
            internal string[] ConvertToStringArray(System.Array values)
            {
                string[] theArray = new string[values.Length];
                for (int i = 1; i <= values.Length; i++)
                {
                    if (values.GetValue(1, i) == null)
                        theArray[i - 1] = "";
                    else
                        theArray[i - 1] = (string)values.GetValue(1, i).ToString();
                }
                return theArray;
            }
    
            internal string ColumnLetter(int columnNumber)
            {
                if (columnNumber > 26)
                {
                    return string.Format("{0}{1}", (char)(Convert.ToInt32((columnNumber - 1) / 26) + 64), (char)(((columnNumber - 1) % 26) + 65));
                }
                else
                {
                    return string.Format("{0}", (char)(columnNumber + 64));
                }
            }
        }
    }
