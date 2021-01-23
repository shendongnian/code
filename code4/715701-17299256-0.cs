    public  Exception exception;
    private void button1_Click(object sender, EventArgs e)
    {
            try
            {
                new Thread(delegate()
                {
                    try
                    {
                        throw new Exception("Bleh"); // <--- This is not caught
                    }
                    catch (Exception e)
                    {
                        exception = e;
                    }
                }).Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if (exception != null)
            {
                //your code here
            }
        }
