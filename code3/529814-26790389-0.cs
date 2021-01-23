    namespace localdatabaseconnect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string conString = Properties.Settings.Default.locallyConnectionString;
        private void button1_Click(object sender, EventArgs e)
        {
            
            // Open the connection using the connection string.
            using (SqlCeConnection con = new SqlCeConnection(conString))
            {
                con.Open();
                // Insert into the SqlCe table. ExecuteNonQuery is best for inserts.
                int id = int.Parse(textBox1.Text);
                string nom = textBox2.Text;
                string prenom = textBox3.Text;
                using (SqlCeCommand com = new SqlCeCommand("INSERT INTO testme (id,nom,prenom) VALUES(@id,@nom,@prenom)", con))
                {
                    com.Parameters.AddWithValue("@id", id);
                    com.Parameters.AddWithValue("@nom", nom);
                    com.Parameters.AddWithValue("@prenom", prenom);
                    com.ExecuteNonQuery();
                }
                con.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlCeConnection con = new SqlCeConnection(conString))
            {
                con.Open();
                // Read in all values in the table.
                using (SqlCeCommand com = new SqlCeCommand("SELECT * FROM testme", con))
                {
                    SqlCeDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        string num = reader[0].ToString();
                        MessageBox.Show("hi"+num);
                    }
                }
                con.Close();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string path = "c:\\ChekatyResources";
         try{
       
          if (!Directory.Exists(path))
            {
          // Try to create the directory.
              DirectoryInfo di = Directory.CreateDirectory(path);
             MessageBox.Show("file is created");
             }
           else {
              MessageBox.Show("file is exist");
      
              }
              }
                catch (IOException ioex)
               {
      MessageBox.Show(ioex.Message);
               }
        
           }
        private void Form1_Load(object sender, EventArgs e)
        {
            //string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
           
            //string path = (System.IO.Path.GetDirectoryName(executable));
            //MessageBox.Show(path);
            //File.WriteAllBytes("destination path",);
            string paths = "c:\\";
            AppDomain.CurrentDomain.SetData("DataDirectory", paths);
            string connStr = @"Data Source =c:\ChekatyResources\locally.sdf;";
            if (!File.Exists(@"c:\ChekatyResources\locally.sdf"))
            {
                SqlCeEngine engine = new SqlCeEngine(connStr);
                engine.CreateDatabase();
                SqlCeConnection conn = null;
                try
                {
                    conn = new SqlCeConnection(connStr);
                    conn.Open();
                    SqlCeCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "CREATE TABLE testme(id int, prenom ntext,nom ntext)";
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                }
                finally
                {
                    conn.Close();
                }
            }
            else { MessageBox.Show("it's exist"); }
        }
    }
