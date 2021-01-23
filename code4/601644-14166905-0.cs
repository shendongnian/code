    static class Program
    {
        static Label label1;
        static Label label2;
        static Form form1;
        static Rectangle rectForm;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form1 = new Form();
            rectForm = form1.ClientRectangle;
            Panel dockTopPanel = new Panel {Height = 100, Dock = DockStyle.Top, BackColor = Color.White };
            label1 = new Label { Text = "Label1", Dock = DockStyle.Left, BackColor = Color.Red, Width = rectForm.Width / 2 };
            label2 = new Label { Text = "Label2", Dock = DockStyle.Right, BackColor = Color.Blue, Width = rectForm.Width / 2 };
             label2.BringToFront();
            Control[] labels= {label1, label2};
            dockTopPanel.Controls.AddRange(labels);
            form1.Controls.Add(dockTopPanel);
            form1.Resize += new EventHandler(form1_Resize);
            Application.Run(form1);
        }
        static void form1_Resize(object sender, EventArgs e)
        {
            rectForm = form1.ClientRectangle;
            label1.Width = (rectForm.Width / 2) + 1;
            label2.Width = (rectForm.Width / 2) + 1;
        }
    }
