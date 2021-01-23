        Form2 f;
        bool isOpen = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (f == null)
            {
                f = new Form2(); ;
                f.FormClosed += new FormClosedEventHandler(f_FormClosed);
            }
            if (!isOpen)
            {
                isOpen = true;
                f.Show();
            }
            
        }
        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            isOpen = false;
        }
    
