    private void doSomething()
    {
        //do something here
    }
    private void button1_Click(object sender, EventArgs e)
    {
        doSomething();
    }
    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Down)
        {
            doSomething();
        }
        else if(e.keyCode==Keys.Right)
        {
             doSomethingElse();
        }
         //etc.etc
    }
