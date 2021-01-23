    private void button1_Click(object sender, EventArgs e)
    {
         TimeSpan ts = stopWatch.Elapsed;  //Here you will get the time interval         
         if(label1.Text != "")
         {
            TimeSpan tsOld =  TimeSpan.Parse(label1.Text);
            label1.Text = ts.Add(tsOld).ToString(); 
         }
         else
            label1.Text = ts.ToString(); 
    }
