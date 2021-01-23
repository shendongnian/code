    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
     namespace WindowsFormsApplication1
     {
      public partial class Form32 : Form
        {
        public Form32()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("row");
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("UserName", typeof(string));
            dt.Rows.Add(1, "Tamer");
            dt.Rows.Add(2, "Foo");
            ds.Tables.Add(dt);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "row";
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            string fileName = @"C:\users\tamer\desktop\data.xml";
            if (File.Exists(fileName))
            {
                DataSet ds = new DataSet();
                ds.ReadXml(fileName);
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "row";
            }
        }
        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            string fileName = @"C:\users\tamer\desktop\data.xml";
            DataSet dataSet = (DataSet)dataGridView1.DataSource;
            dataSet.WriteXml(fileName);
        }
    }
