    private void button1_Click(object sender, EventArgs e)
    {
        // Form2 or Form3 in your example
        ChildForm1 child1 = new ChildForm1();
        child1.UpdateData += UpdateDataFormEvent;
        child1.Show(); 
    }
    
    void UpdateDataFormEvent(object sender)
    {
        Form frm = sender as Form; // just cast it back to form
        MessageBox.Show(frm.Text);   
    }
