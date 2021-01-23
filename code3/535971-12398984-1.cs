    //This event will fire each 10 seconds
    private void timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) 
    {
     if (progressBar1.Value ! = 10)
     {
        progressBar1.Value = progressBar1.value + 1;
     }
    }
