            EXCEL.Workbook book = excel.Application.Workbooks.Open(path);
            EXCEL.Worksheet sheet = book.Worksheets[1];
            // yout operation
        }
        catch (Exception ex) { MessageBox.Show("readExcel:" + ex.Message); }
        finally
        {
            KillExcel(excel);
            System.Threading.Thread.Sleep(100);
        }
    [DllImport("User32.dll")]
    public static extern int GetWindowThreadProcessId(IntPtr hWnd, out int ProcessId);
    private static void KillExcel(EXCEL.Application theApp)
    {
        int id = 0;
        IntPtr intptr = new IntPtr(theApp.Hwnd);
        System.Diagnostics.Process p = null;
        try
        {
            GetWindowThreadProcessId(intptr, out id);
            p = System.Diagnostics.Process.GetProcessById(id);
            if (p != null)
            {
                p.Kill();
                p.Dispose();
            }
        }
        catch (Exception ex)
        {
            System.Windows.Forms.MessageBox.Show("KillExcel:" + ex.Message);
        }
    }
