    //USING
    		using System;
    		using System.Drawing;
    		using System.Windows.Forms;
    		using System.Data.SqlClient;
    		using System.Data;
    
    namespace YourNamespace
    {
    //Initialization
    		string connetionString = null;
    		SqlConnection cnn;
    		SqlCommand cmdDataBase;
    		SqlDataReader reader;
    		DataTable dt;
    
    public frmName()
    		{
    			//
    			// The InitializeComponent() call is required for Windows Forms designer support.
    			//
    			InitializeComponent();
    			//
    			// TODO: Add constructor code after the InitializeComponent() call.
    			//
    			FillComboNameOfCombo();
    		}
    
    void FillcmbNameOfCombo()
    {
    	string sqlQuery = "SELECT * FROM DATABASENAME.[dbo].[TABLENAME];";
               	connetionString = "Data Source=YourPathToServer;Initial Catalog=DATABASE_NAME;User ID=id;Password=pass";
                	    cnn = new SqlConnection(connetionString); 
                	    cmdDataBase = new SqlCommand(sqlQuery, cnn);
               	try { 
                    	cnn.Open(); 
                    	
                    	reader = cmdDataBase.ExecuteReader();
                    	dt = new DataTable();
                    	
                    	dt.Columns.Add("ID", typeof(string));
                    	dt.Columns.Add("COLUMN_NAME", typeof(string));
                    	dt.Load(reader);
                    	cnn.Close();
                    	
                    	cmbGender.DataSource = dt;
                    	cmbGender.ValueMember = "ID";
                    	cmbGender.DisplayMember = "COLUMN_NAME";
                    	
                    	dt = null;
                    	cnn = null;
                    	cmdDataBase = null;
                    	connetionString = null;
                    	reader = null;
                	}
               	catch (Exception ex) { 
                        MessageBox.Show("Can not open connection ! " + ex.ToString());
                	}
    }
    }
