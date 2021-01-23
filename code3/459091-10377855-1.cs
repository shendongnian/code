    private void btn1_Click(object sender, EventArgs e)
    {
        // Create form2
        Form2 frm2 = new Form2();
        // Handle btn2 click
        frm2.btn2_Clicked += new Form2.GetValue(frm2_btn2_Clicked);
        // Show form2
        frm2.Show();
    }
    void frm2_btn2_Clicked(string value)
    {
        // When btn2 is clicked, the text in txt2 will be assign to txt1
        txt1.Text = value;                
    }
