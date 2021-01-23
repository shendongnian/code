    myForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
         clickCounter--;
    }
    private void pictureBox1_Click(object sender, EventArgs e)
    {
        if (clickCounter < 10) // arbitrary number
        {
            clickCounter++;
            var myForm = new Form2();
            myForm.Closing += myForm_Closing;
            myForm.Show();
        }
    }
