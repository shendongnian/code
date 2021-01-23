        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm mf  = new MainForm();
            if (mf.ShowDialog() == DialogResult.OK) 
            {  
               subForm newSubForm = new subForm();   
               newSubForm.RegisterMainForm(this);                        
               Application.Run(newSubForm); 
            }
        }
