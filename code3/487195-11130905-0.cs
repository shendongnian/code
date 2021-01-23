    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace SampleConsole
    {
        class Program
        {
            [STAThread]
            static void Main(string[] args)
            {
                if (Clipboard.ContainsText(TextDataFormat.Text))
                {
                    string clipBoardText = Clipboard.GetText(TextDataFormat.Text);
                    Console.WriteLine(clipBoardText);
                    Console.Read();
                }
                
            }
        }
    }
