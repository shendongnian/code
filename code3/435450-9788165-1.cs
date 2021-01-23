     using System;
     using System.Text;
     using System.Runtime.InteropServices;
     using System.Diagnostics;
     using Excel = Microsoft.Office.Interop.Excel;
     using System.Timers;
    class Program
    {
       private const int SLEEP_AMOUNT = 1000;
       private const int MAXIMUM_EXECUTION_TIME = 10000;
       private Excel.Application excelApp =null;
       private Excel.Workbook book =null;
       private Timer myTimer;
       private int elapsedTime;
       private int exitCode=0;
       [DllImport("user32.dll", SetLastError =true)]
       static extern uint GetWindowThreadProcessId(IntPtr hWnd,out uint lpdwProcessId);
       static int Main(string[] args)
        {
           Program myProgram = newProgram();
           myProgram.RunExcelReporting(1);
           return myProgram.exitCode;
        }
 
       void myTimer_Elapsed(object sender,ElapsedEventArgs e)
        {
           myTimer.Stop();
           elapsedTime += SLEEP_AMOUNT;
           if (elapsedTime > MAXIMUM_EXECUTION_TIME)
            {
                //error in vba or maximum time reached. abort excel and return 1 to the calling windows forms application
               GC.Collect();
               GC.WaitForPendingFinalizers();
               if (book != null)
                {
                   book.Close(false,Type.Missing, Type.Missing);
                   Marshal.FinalReleaseComObject(book);
                   book =null;
                }
               if (excelApp != null)
                {
                   int hWnd = excelApp.Hwnd;
                   uint processID;
                   GetWindowThreadProcessId((IntPtr)hWnd,out processID);
                   if (processID != 0)
                       Process.GetProcessById((int)processID).Kill();
                    excelApp =null;
                    exitCode = 1;
                }
            }
           else
            {
                myTimer.Start();
            }
        }
 
       void RunExcelReporting(int x)
        {
            myTimer =new Timer(SLEEP_AMOUNT);
            elapsedTime = 0;
            myTimer.Elapsed +=new ElapsedEventHandler(myTimer_Elapsed);
            myTimer.Start();
           try{
                excelApp =new Excel.Application();
                excelApp.Visible =true;
                book = excelApp.Workbooks.Open(@"c:\jsauto.xlsm");
                excelApp.Run("ThisWorkbook.rr");
                book.Close(false,Type.Missing, Type.Missing);
            }
            catch (Exception ex){
               Console.WriteLine(ex.ToString());
            }
           finally
            {
               //no error in vba and maximum time is not reached. clear excel normally
               GC.Collect();
               GC.WaitForPendingFinalizers();
               if (book != null)
                {
                   try {
                        book.Close(false,Type.Missing, Type.Missing);
                    }
                    catch { }
                   Marshal.FinalReleaseComObject(book);
                }
               if (excelApp != null)
                {
                   excelApp.Quit();
                   Marshal.FinalReleaseComObject(excelApp);
                   excelApp =null;
                }
            }
        }
    }
