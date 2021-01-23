    using System;
    using System.Threading;
    using System.Windows.Forms;
    
    class Program
    {
        private Program()
        {
            // Actual form is created in Start...
        }
        
        private void StartAndLoop()
        {
            Label label = new Label { Text = "Nothing" };
            Form form = new Form { Controls = { label } };
            new Thread(() => Application.Run(form)).Start();
            // TODO: We have a race condition here, as if we
            // read a line before the form has been fully realized,
            // we could have problems...
             
            while (true)
            {
                string line = Console.ReadLine();
                Action updateText = () => label.Text = line;
                label.Invoke(updateText);
            }
       }
        
        static void Main(string[] args)
        {
            new Program().StartAndLoop();
        }
    }
