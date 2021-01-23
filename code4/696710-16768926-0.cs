    bool flag=false;
    public void Somthing()
    {
      ///some code...
      ///
      setFlag(true);
    }
    
    protected void panel_paint(PainteventArgs e)
    {
     if(flag==true)
       //draw some text
    }
    private void setFlag(bool f)
    {
        flag = f;
        Invalidate();
    }
