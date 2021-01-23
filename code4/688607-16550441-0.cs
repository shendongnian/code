    using System;
    using System.Windows.Forms;
    using System.Collections.Generic;
    using System.Linq;
    public partial class Form1 : Form
    {
        // keep list of listview items 
        List<Data> Items = new List<Data>();
        public Form1()
        {
            InitializeComponent();
            // get initial data
            Items = new List<Data>(){
                new Data(){ Id =1, Name ="A"},
                new Data(){ Id =2, Name ="B"},
                new Data(){ Id =3, Name ="C"}
            };
            // adding initial data
            listView1.Items.AddRange(Items.Select(c => new ListViewItem(c.Name)).ToArray());
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear(); // clear list items before adding 
            // filter the items match with search key and add result to list view 
            listView1.Items.AddRange(Items.Where(i=>string.IsNullOrEmpty(textBox1.Text)||i.Name.StartsWith(textBox1.Text))
                .Select(c => new ListViewItem(c.Name)).ToArray());
        }
    }
    class Data
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
