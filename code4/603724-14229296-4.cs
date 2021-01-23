    private void StartUpdateTimer()
    {
        var timer = new System.Threading.Timer((o) => 
        { 
            string ss = "gowtham " + DateTime.Now.ToString(); 
            Response.Write(ss); 
        }, null, 0,1000);
    }
