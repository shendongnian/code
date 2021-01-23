        DateTime dtmCurrentDateTime = DateTime.Now.ToUniversalTime();
        double dblMinutes =Convert.ToDouble(Session["TimeOffset"].ToString());                
        dtmCurrentDateTime = dtmCurrentDateTime.AddMinutes(-dblMinutes);
     
 
