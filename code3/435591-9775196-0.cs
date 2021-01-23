    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    class Test
    {
        static void Main()
        {
            Form form = new Form();
            for (int i = 0; i < 4; i++)
            {
                Button button = new Button
                {
                    Text = "Dummy",
                    Location = new Point(10, i * 25)
                };
                form.Controls.Add(button);
            }
            Button disabler = new Button
            {
                Text = "Disable",
                Location = new Point(10, 100)
            };
            disabler.Click += delegate
            {
                foreach (Control c in form.Controls)
                {
                    c.Enabled = false;
                }
            };
            form.Controls.Add(disabler);
            Application.Run(form);
        }                   
    }
