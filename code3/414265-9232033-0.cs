    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Data.SqlClient;
    namespace MySqlTest
    {
    public partial class Form1 : Form
    {
        int myCount;
        string myDBlocation = @"Data Source=MEDESKTOP;AttachDbFilename=|DataDirectory|\mySQLtest.mdf;Integrated Security=True;User Instance=False";
        public Form1()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            myCount++;
            MessageBox.Show("myCount = " + myCount.ToString());
            //Insert Record Into  SQL File
            myDB_Insert();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //Read Record From SQL File
        }
        private void button4_Click(object sender, EventArgs e)
        {
            //Read All Records From SQL File
        }
        private void button5_Click(object sender, EventArgs e)
        {
            //Delete Record From SQL File
        }
        private void button7_Click(object sender, EventArgs e)
        {
            //Quit
            myDB_Close();
            this.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void Form1_Close(object sender, EventArgs e)
        {
        }
        void myDB_Insert()
        {
            using (SqlConnection myDB = new SqlConnection(myDBlocation))
            using (SqlCommand mySqlCmd = myDB.CreateCommand())
            {
                myDB.Open(); **<<< Program fails here, 2nd time through**
                mySqlCmd.CommandText = "INSERT INTO Parent (ParentName) VALUES(@ParentNameValue)";
                mySqlCmd.Parameters.AddWithValue("@ParentNameValue", myCount);
                mySqlCmd.ExecuteNonQuery();
                myDB.Close();
            }
            return;
        }
        void myDB_Close()
        {
            using (SqlConnection myDB = new SqlConnection(myDBlocation))
            using (SqlCommand mySqlCmd = new SqlCommand())
            {
                myDB.Close();
            }
            return;
        }
    }
    }
