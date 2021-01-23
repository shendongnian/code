    private void ThreadSafe(MethodInvoker method)
    {
        try
        {
            if (InvokeRequired)
                Invoke(method);
            else
                method();
        }
        catch
        { }
    }
    ///////////////////////
    pictureBox1.Image = img;
