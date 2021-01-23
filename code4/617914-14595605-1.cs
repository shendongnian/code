    //Button1Click Event
        private void button1_Click(object sender, EventArgs e)
        {
            UserControl1 m_UserControl = new UserControl1();
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(m_UserControl);
        }
        //Button2Click Event
        private void button2_Click(object sender, EventArgs e)
        {
            UserControl2 m_Usercontrol2 = new UserControl2();
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(m_Usercontrol2);
        }
