    private void acceptAlert(){
    string alertText = "";
    IAlert alert = null;
    while (alertText.Equals("")){
    if (alert == null)
    {
    try{
    alert = driver.SwitchTo().Alert();
    }
    catch{ 
    System.Threading.Thread.Sleep(50); }
    }
    else{
    try{
    alert.Accept();
    alertText = alert.Text;
    }
    catch (Exception ex){
    if (ex.Message.Equals("No alert is present")) alertText = "Already Accepted";
    else System.Threading.Thread.Sleep(50);
    }
    }
    }
    }
