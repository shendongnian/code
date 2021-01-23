    public ActionResult GetReport(string pNum)
    {
    ....
        ActionResult actionResult;
        switch (methodId)
        {
            case 1:
            case 5:                
            {
                actionResult = GetP1Report("33996",false) as ActionResult;
                break;
             }
         }
         return actionResult; 
       }
