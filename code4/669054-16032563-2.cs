        public void addDevice_Click(object sender, EventArgs e)
        {
            try
            {
                h.BackColor = Color.Green; ;
                comport.Write("AB");
                comport.Write(num);
                comport.Write(" "); 
                stausLable.Text = "Device "+num+" added";
                comport.WriteLine("000000000000");
            }
            catch (InvalidOperationException )
            {
                stausLable.Text = "Open communication port";
               
            }
        }
