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
                    Console.WriteLine("TEXT in ClipBoard : " + clipBoardText);
    
                    Console.WriteLine("Type text to replace (and press Enter key) :");
                    string replaceText = Console.ReadLine();
                    Clipboard.SetText(replaceText);
                    Console.WriteLine("REPLACED ClipBoard Text : " + Clipboard.GetText(TextDataFormat.Text));               
                }
                else
                {
                    Console.WriteLine("No text in clipboard, please type now (and press Enter key) :");
                    string newText = Console.ReadLine();
                    Clipboard.SetText(newText);
                    Console.WriteLine("NEW ClipBoard Text : " + Clipboard.GetText(TextDataFormat.Text));    
                }
    
                Console.Read();
            }
        }
    }
