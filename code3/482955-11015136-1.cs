    private void Form1_Load(object sender, EventArgs e)
    {
        if(myReader.HasRows == true)
        {
            myReader.Read();
            if(myReader.IsDBNull(0) == false)
                textBox1.Text = myReader.GetInt32(0).ToString();
        }
    }
