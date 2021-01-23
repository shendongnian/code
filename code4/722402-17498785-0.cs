    1. Create new Reminder form every time you want to show it.
    2. Add code to `FormClosing` event handler to Cancel the Closing operation and just hide it instead like this:
        public Form1()
       {
         InitializeComponent();
         var data = new BirthdayEntities();
         dataGridView1.DataSource = data.Tab_Bday.ToList();
         //add this
         forma.FormClosing += forma_FormClosing;
         timer.Tick += new EventHandler(timer_Tick); 
         timer.Interval = (1000) * (1);                      
         timer.Start();                              
       }
       private void forma_FormClosing(object sender, FormClosingEventArgs e){
         if(e.CloseReason == CloseReason.UserClosing){
             e.Cancel = true;
             forma.Hide();
         }
       }
