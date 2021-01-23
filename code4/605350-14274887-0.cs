    internal class MyHistory {
        internal static Form LastForm;
    }
    
    // ........
    
    private void button1_Click(object sender, EventArgs e)
    {
        MyHistory.LastForm = this;
        this.Hide();
    }
    
    // ........
    
    private void button3_Click(object sender, EventArgs e)
    {
        MyHistory.LastForm.Show();
    }
