    class Delay
    {
        public int ErrorCode { get; private set; }
        public void Convert()
        {
            ErrorCode = 1;
            ...
        }
    }
    private void btnStart_Click(object sender, EventArgs e)
    {
        Delay delay = new Delay();
        Thread t = new Thread(delay.Convert);
        //something
        int error = delay.ErrorCode;
        MessageBox.Show("Success");
    }
