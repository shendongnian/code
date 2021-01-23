     private void Form1_Load(object sender, EventArgs e)
        {            
            timer1.Start();            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Web_Reference.Service1 service = new Web_Reference.Service1();
            DataTable dt = service.GetData();
            textBox1.Text = dt.Rows[0]["Current_Amount"].ToString();
            textBox2.Text = dt.Rows[0]["Current_Qty"].ToString();
            textBox3.Text = dt.Rows[0]["Rate"].ToString();            
        }
