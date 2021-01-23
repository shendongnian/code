Click the Button to update the read-only column value.
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                List<Book> books = new List<Book>();
                books.Add(new Book() { Name = "C#" });
               
                InitializeComponent();
    
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = books;
                dataGridView1.Refresh();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                dataGridView1[0,0].Value = "Winforms";
            }
       }
    
        public class Book
        {
            public string Name { get; set; }
        }
    }
