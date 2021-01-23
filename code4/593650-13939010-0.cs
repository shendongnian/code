    public Form Form1
    {
        public string PortNum {get;set;}
    
        public void ComboBox1_SelectionChanged(object sender, EventArgs e)
        {
           PortNum = ComboBox1.SelectedItem.ToString();
        }
    
        ... (rest of your code)
    
    }
