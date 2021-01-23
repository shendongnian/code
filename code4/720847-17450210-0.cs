    public void delegate MyDelegate();
    
    MyDelegate del = this.insertTemplate;
    
    private void sqlQuery(MyDelegate sqlMethod)
    {
     ...
     del();
     ...
    }
