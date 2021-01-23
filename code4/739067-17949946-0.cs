    ... In your form code ...
    
    ClassNameHere myOb = new ClassNameHere();
    myOb.FileComplete += new FileCompleteHandler(FileDone);
    ...
    
    public void FileDone(object sender, EventArgs e)
    {
        if (InvokeRequired)
        {
            Invoke(new FileCompleteHandler(FileDone), new object[] { sender, e });
            return;
        }
        
        ... update UI here ...
    }
    
