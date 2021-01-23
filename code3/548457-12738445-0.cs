    private void Create_Thread()
    {
        //Parameterized function
        Thread wt = new Thread(new ParameterizedThreadStart(this.DoWork));
        wt.Start([/*Pass parameters here*/]);
    }
    public void DoWork(object data)
    {
        Thread.Sleep(1000);
        //Process Data - Do Work Here
        //Call Delegate Method to Process Result Data
        Post_Result(lvitem);
    }
    private delegate void _Post_Result(object data);
    private void Post_Result(object data)
    {
        //Process Result
    }
