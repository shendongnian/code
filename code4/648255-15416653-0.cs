    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;
    
    class Form1 : Form
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    
        Timer queryTimer;
        TextBox SearchField;
    
        public Form1()
        {
            Controls.Add((SearchField = new TextBox { Location = new Point(10, 10) }));
            SearchField.TextChanged += new EventHandler(SearchField_TextChanged);
        }
    
        void SearchField_TextChanged(object sender, EventArgs e)
        {
            if (SearchField.Text.Length < 3)
                RevokeQueryTimer();
            else
                RestartQueryTimer();
        }
    
        void RevokeQueryTimer()
        {
            if (queryTimer != null)
            {
                queryTimer.Stop();
                queryTimer.Tick -= queryTimer_Tick;
                queryTimer = null;
            }
        }
    
        void RestartQueryTimer()
        {
            // Start or reset a pending query
            if (queryTimer == null)
            {
                queryTimer = new Timer { Enabled = true, Interval = 500 };
                queryTimer.Tick += queryTimer_Tick;
            }
            else
            {
                queryTimer.Stop();
                queryTimer.Start();
            }
        }
    
        void queryTimer_Tick(object sender, EventArgs e)
        {
            // Stop the timer so it doesn't fire again unless rescheduled
            RevokeQueryTimer();
            // Perform the query
            Trace.WriteLine(String.Format("Performing query on text \"{0}\"", SearchField.Text));
        }
    }
