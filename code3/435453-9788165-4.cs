    public partial class Form1 : Form
    {
       SqlDataAdapter myAdapt = null; 
       DataSet mySet =null; 
       DataTable myTable =null; 
 
       public Form1()
        { InitializeComponent();}
        privatevoid Form1_Load(object sender,EventArgs e){ 
            InitializeGridView();
        }
       private Process myProcess;
       private void btRunProcessAndRefresh_Click(object sender,EventArgs e)
        {
            myProcess =new Process();
            myProcess.StartInfo.FileName =@"c:\VS2010Projects\ConsoleApplication2\ConsoleApplication4\bin\Debug\ConsoleApplication4.exe";
            myProcess.Exited +=new EventHandler(MyProcessExited);
            myProcess.EnableRaisingEvents =true;
            myProcess.SynchronizingObject =this;
            btRunProcessAndRefresh.Enabled =false;
            myProcess.Start();
        }
        privatevoid MyProcessExited(Object source,EventArgs e)
        {
            InitializeGridView();
            btRunProcessAndRefresh.Enabled =true;
           if (((Process)source).ExitCode == 1)
            {
               MessageBox.Show("Excel was aborted");
            }
           else
            {
               MessageBox.Show("Excel finished normally");
            }
        }
       private void btnALWAYSWORKS_Click(object sender,EventArgs e) { 
            InitializeGridView();
        }
        privatevoid InitializeGridView() { 
          using (SqlConnection conn =new SqlConnection(@"Data Source=sqliom3;Integrated Security=SSPI;Initial Catalog=CCL"))
            {
            myAdapt =new SqlDataAdapter("SELECT convert(varchar(25),getdate(),120) CurrentDate", conn);
            mySet =new DataSet();
            myAdapt.Fill(mySet,"AvailableValues"); 
            myTable = mySet.Tables["AvailableValues"];
            this.dataGridViewControlTable.DataSource = myTable;
            this.dataGridViewControlTable.AllowUserToOrderColumns =true;
            this.dataGridViewControlTable.Refresh();
            }
        }
      }
