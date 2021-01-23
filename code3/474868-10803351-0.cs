    using System;
    using System.Windows.Forms;
    using System.Drawing;
    
    namespace TextMeasureExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(TextRenderer.MeasureText("This is some text", new Font("Arial", 0.75f)));
            }
        }
    }
