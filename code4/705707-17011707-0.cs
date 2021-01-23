    object tag;
    private void Buttons_Click(System.Object sender, System.EventArgs e)
    {
        isclicked = true;
        // Used "Sender" to know which button was clicked ?
        Button btn = sender as Button;      
        tag = btn.Tag;
    }
    private void button5_Click(object sender, EventArgs e)
    {
        if (textBox1.Text != "")
        {
            SqlConnection conn = new SqlConnection(@"server=.\SQLEXPRESS;
            Initial Catalog=DUK1;Integrated Security=True;Pooling=False");
            command.Connection = conn;
            conn.Open();      
            command.CommandText = "select product_PRIZE from T_Product where PRODUCT_ID = '" + tag != null ? tag : "" + "'";
            textBox5.Text = comando.ExecuteScalar().ToString();
        }
     }
