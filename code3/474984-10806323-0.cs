    private DateTime _dateTime = DateTime.Now;
    
    public void ProcessRequest(HttpContext context)
    {
        context.Response.Write(_dateTime);
    }
