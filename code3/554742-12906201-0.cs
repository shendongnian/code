    protected void Button3_Click(object sender, EventArgs e)
    {
        MyMethod(null);
    }
    public void MyMethod(String thing)
    {
        if (thing == null)   //  This caused the exception to be thrown.
            throw new Exception("test");
        //Do other stufff....
    }
