    ListWithRTB _mlrtb = new ListWithRTB();
        private void button1_Click(object sender, EventArgs e)
        {
            _mlrtb.rtb = richTextBox1;
            _mlrtb.Add("Filter");
            _mlrtb.Add("123");
            _mlrtb.Add("111 Filter");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            _mlrtb.Filter("Filter");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            _mlrtb.Filter("");
        }
        
