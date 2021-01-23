    private bool _flag;
    public bool Flag
    {
        get { return _flag; }
        set
        {
            _flag = value;
            Invalidate();
        }
    }
    
    public void Somthing()
    {
        ///some code...
        ///
        Flag = true;
    }
    
    protected void panel_paint(PainteventArgs e)
    {
        if(Flag == true)
            //draw some text
    } 
