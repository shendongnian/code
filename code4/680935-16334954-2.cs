        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
             try
            {
                var App = new Microsoft.Office.Interop.Excel.Application();
                if (App == null)
                    System.Windows.Forms.MessageBox.Show("App is null");
                else
                {
                    App.Workbooks.Add();
                    var Sheet = App.ActiveSheet;
                    if (Sheet == null)
                        System.Windows.Forms.MessageBox.Show("Sheet is null");
                    else
                    {
                        var Rng = Sheet.Range["A1:A5,A15:A25,A50:A65"];
                        if (Rng == null)
                            System.Windows.Forms.MessageBox.Show("Rng is null");
                        else
                        {
                            Rng.Select();
                            App.Selection.Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbYellow;
                            App.ActiveWorkbook.SaveAs("testtest.xlsx");
                            App.Quit();
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                System.Windows.Forms.MessageBox.Show("Exception: " + ee.Message);
            }
        }
