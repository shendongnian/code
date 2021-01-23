    public partial class Form2 : Form
    {
        public delegate void AddGraphPointsTemp();
        public AddGraphPointsTemp myDelegate1;
        Thread tempThread;
        string myConnection;
        MySqlConnection conDataBase;
        MySqlCommand cmdDataBase;
        MySqlDataReader myReader;
            
        public Form2()
        {
            InitializeComponent();
            myDelegate1 = new AddGraphPointsTemp(AddGraphPointsMethodTemp);
            myConnection = "datasource=localhost;port=3306;username=root;password=root";
            conDataBase = new MySqlConnection(myConnection);
            cmdDataBase = new MySqlCommand(" select * from data.test; ", conDataBase);
            conDataBase.Open();
            myReader = cmdDataBase.ExecuteReader();
                
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            conDataBase.Close();
            Application.Exit();
        }
        public void AddGraphPointsMethodTemp()
        {
            try
            {
                
                    myReader.Read();
                    chartTemperature.Series["Temperature"].Points.AddXY(myReader.GetString("datetime"), myReader.GetInt32("temp"));
                    chartTemperature.Update();
                    
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnTemperature_Click(object sender, EventArgs e)
        {
            tempThread = new Thread(ThreadFunction1);
            tempThread.Start(this);
        }
     
        public static void ThreadFunction1(Object obj)
        {
            while (true)
            {
                Form2 myForm2 = (Form2)obj;
                myForm2.Invoke(myForm2.myDelegate1);
                Thread.Sleep(300);
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
        }
   
    }
}
