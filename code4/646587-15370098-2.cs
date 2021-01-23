    using System;
    using System.Windows.Forms;
    using System.Text;
    using System.IO;
    
    namespace NS
    {
    
        class Program
        {
            [STAThread]
            static void Main(string[] args)
            {
                try
                {
                    Console.SetIn(new StreamReader(Console.OpenStandardInput(2000)));
                    //get some content using Console.ReadLine() and prompting using Console.WriteLine();
                    string HTML = "<html>";
                    //string.Format(@"HTML redacted", someFormatString, w / e);
                    Clipboard.SetText(HTML);
                    Console.ReadKey(true);
                    string JS = "JS { }";//string.Format(@"JS redacted", someFormatString, w / e);
                    Clipboard.SetText(JS);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey(true);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    Console.ReadKey();
                }
            }
        }
    }
