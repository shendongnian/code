    using xl = Microsoft.Office.Interop.Excel;
    // use in a console app
    class Program
    {
        static void Main(string[] args)
        {
            xl.Application app = new xl.Application();
            app.Visible = true;
            xl.Workbook wb = app.Workbooks.Add();
            xl.Worksheet worksheet1 = wb.Sheets[1];
            xl.Worksheet worksheet2 = wb.Sheets[2];
            xl.Range rngS1A1 = worksheet1.Range["A1"];
            xl.Range rngS1A2 = worksheet1.Range["A2"];
            xl.Range rngS2B1 = worksheet2.Range["B1"];
            xl.Range rngS2C1 = worksheet2.Range["C1"];
            rngS1A1.Formula = @"=sheet2!C1";
            rngS1A2.Formula = @"=sheet2!C1";
            ((xl._Worksheet)worksheet2).Activate();
            rngS2B1.Formula = @"=C1";
            List<string> dependentAddresses = ListDependents(rngS2C1);
            foreach (string address in dependentAddresses)
            {
                Console.WriteLine(address);
            }
            Console.WriteLine("done, press enter to exit");
            Console.ReadLine();
        }
        private static List<string> ListDependents(xl.Range sourceRange)
        {
            sourceRange.ShowDependents(false);
            string sourceAddress = sourceRange.Worksheet.Name + "!" + sourceRange.Address;
            int arrowNumber = 1;
            List<string> dependentAddresses = new List<string>();
            do
            {
                string targetAddress = null;
                int linkNumber = 1;
                do
                {
                    try
                    {
                        xl.Range target = sourceRange.NavigateArrow(TowardPrecedent: false, ArrowNumber: arrowNumber, LinkNumber: linkNumber++);
                        targetAddress = target.Worksheet.Name + "!" + target.Address;
                        if (sourceAddress == targetAddress) break;
                        dependentAddresses.Add(targetAddress);
                    }
                    catch (COMException cex)
                    {
                        if (cex.Message == "NavigateArrow method of Range class failed")
                        {
                            break;
                        }
                        throw;
                    } 
                } while (true);
                if (sourceAddress == targetAddress) break;
                arrowNumber++;
            } while (true);
            sourceRange.Worksheet.ClearArrows();
            return dependentAddresses;
        }
    }
