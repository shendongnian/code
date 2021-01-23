    using System;
    using System.Collections.Generic;
    using XYZ.TransactionsModule;
    
    namespace XYZ
    {
        public partial class frmReports : Form
        {      
            public frm1()
            {
                InitializeComponent();
                protected TransactionsModule moduleTran;
            }
    
            private void frm1_Load(object sender, EventArgs e)
            {
                //We initialize the Data Access Layer class
                moduleTran = new TransactionsModule();
    
                //This ConnectionString should be in your app.config
                string conString = "provider= microsoft.jet.oledb.4.0;data source=..\\dbCooperative.mdb";
                string sqlQuery = "SELECT * FROM table";
    
                List<Person> ItStaff = moduleTran.GetPersons(sqlQuery, conString);
            }
        }
    }
