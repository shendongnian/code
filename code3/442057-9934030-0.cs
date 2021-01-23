    private void DoSomething(int value)
    {
       ...
    }
    
    private void trackBar1_Scroll(object sender, EventArgs e)
    {
       DoSomething(trackBar1.Value);
    }
    
    private void label4_Click(object sender, EventArgs e)
    {
       DoSomething(...);
    }
