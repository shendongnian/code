    private void Form1_Load(object sender, EventArgs e)
    {
        try
        {
            REngine.SetDllDirectory(@"C:\Program Files\R\R-2.13.1\bin\i386");            
            REngine engine = REngine.CreateInstance("RDotNet");
            engine.Evaluate("WQ<-read.csv('c:\\Documents and Settings\\hardinmvarghese\\Desktop\\reg.csv')");
            engine.EagerEvaluate("rst <- lm(V1 ~ V2+V3+V4+V5,WQ)");
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.GetType().ToString() + " " + ex.Message);
        }
    }
