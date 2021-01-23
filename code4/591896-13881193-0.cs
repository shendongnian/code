    public class MyDBRecord
    {
        public int ID { get; set; } 
        public string Text { get; set; }
        public MyDBRecord(int _id, string _text)
        {
            ID = _id;
            Text = _text;
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        listBox1.DisplayMember = "Text";
        listBox1.ValueMember = "ID";
    
        listBox1.Items.Add(new MyDBRecord(1, "abc"));
        listBox1.Items.Add(new MyDBRecord(2, "def"));
        listBox1.Items.Add(new MyDBRecord(3, "hij"));
    }
    
    private void button2_Click(object sender, EventArgs e)
    {
        MyDBRecord Selected;
    
        Selected = listBox1.SelectedItem as MyDBRecord;
    
        if (Selected != null)
            MessageBox.Show(Selected.ID.ToString());     
    }
