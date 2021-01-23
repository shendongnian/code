        public bool IsValidated()
        {
        return !String.IsNullOrEmpty(textBox1.Text);
        }
    private void button4_Click(object sender, EventArgs e)
    {
            bool passed = IsValidated();
    }
        
