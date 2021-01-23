    public class Form1
    {
            protected void Form1_Load(object sender, EventArgs e)
            {
                  Greyhound gh = new Greyhound(this);//pass the form as 'this'
                  //then you can call gh.Run()
            }
    }
