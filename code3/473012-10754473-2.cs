    void Button_Click(object sender, EventArgs e)
            {
                if ((sender as Button) == btn1)
                {
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else if ((sender as Button) == btn2)
                {
                    dataGridView1.DataSource = ds.Tables[1];
                }
            }
////
    if(b==1)
    {
    dataGridView1.DataSource = ds.Tables[0];
    }
    else if(b==2)
    {
    dataGridView1.DataSource = ds.Tables[1];
    }
