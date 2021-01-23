                Excel.Application exap = new Microsoft.Office.Interop.Excel.Application();
                Excel.Workbook wb = exap.Workbooks.Open(sourceFileNameTextBox.Text,
    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
    Type.Missing, Type.Missing);
                Excel.Sheets sh = wb.Worksheets;
                    bool clip = false;
                    // copy excel cells to clipboard
                    while (!clip)
                    {
                        try
                        {
                            ws.Cells.get_Range(cells[0], cells[1]).Copy(Type.Missing);
                            clip = true;
                        }
                        catch
                        {
                            clip = false;
                        }
                    }
                    string b = "";
                    // get excel cells data from clipboard as HTML
                    clip = false;
                    while(!clip)
                    {
                        try
                        {
                            b = Clipboard.GetData(DataFormats.Html) as string;
                            clip = true;
                        }
                        catch
                        {
                            clip = false;
                        }
                    }
