    Font  myFont = new Font("Aerial", 10, FontStyle.Regular);
  
    private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
    {        
        if (e.Index == 1)//We are disabling item based on Index, you can have your logic here
        {
            e.Graphics.DrawString(comboBox1.Items[e.Index].ToString(), myFont, Brushes.LightGray, e.Bounds);
        }
        else
        {
            e.DrawBackground();
            e.Graphics.DrawString(comboBox1.Items[e.Index].ToString(), myFont, Brushes.Black, e.Bounds);
            e.DrawFocusRectangle();
        }
    } 
     void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
                comboBox1.SelectedIndex = -1;
        }
