    bool status = true;
    if (xxx > 100)
    { 
        errMsg = "Number of xxx should be <= 100";
        swRpt.WriteLine(errTitle + errMsg);
        status = false;
    }
    // sizing
    
    swRpt.WriteLine("   Epsilon");
    
    //Repair
    success = Numerical.Check("repair", inputs.repair.ToString(), 
                              out dtester, out errMsg);
    if (!success)
    {
        swRpt.WriteLine(errTitle + errMsg);
        status = false;
    }
    success = Numerical.Check("prob", inputs.prob.ToString(), 
                              out dtester, out errMsg);
    if (!success)
    {
        swRpt.WriteLine(errTitle + errMsg);
        status = false;
    }
    
    return status;
