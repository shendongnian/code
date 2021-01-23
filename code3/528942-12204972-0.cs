        private void Form1_Load(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = true;
            toolStripButton1.Enabled = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1.Hide();
            toolStripButton1.Enabled = true;
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel1Collapsed)
            {
                toolStripButton1.Enabled = false;
                splitContainer1.Panel1.Show();
            }
        }
