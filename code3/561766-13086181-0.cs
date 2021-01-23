    public int Counter { get; set; }
    
    private void button1_Click(object sender, System.EventArgs e) {
        Counter++;
        textbox1.Text = Counter.ToString("X");
    }
