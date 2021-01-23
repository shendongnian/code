    Exception actualException = null;
    using (AutoResetEvent waitHandle = new AutoResetEvent())
    {
        instance.Save(xmlDocument, ex =>
        {
            actualException = ex;
            waitHandle.Set();
        });
        waitHandle.WaitOne();
    }
    Assert.IsNull(actualException);
