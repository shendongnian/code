    public void button_Click(object sender, EventArgs e)
    {
     if( sender == buttonArray[0] )
      {
      MessageBox.Show("hello");
       }
     }
    private void button1_Click(object sender, EventArgs e)
    {
        int h =3;
        Button[] buttonArray = new Button[8];
        for (int i = 0; i <= h-1; i++)
        {
           buttonArray[i] = new Button();
           buttonArray[i].Size = new Size(20, 43);
           buttonArray[i].Name= ""+i+"";
           buttonArray[i].Click += button_Click;//function
           buttonArray[i].Location = new Point(40, 20 + (i * 20));
            panel1.Controls.Add(buttonArray[i]);
        }
    }
