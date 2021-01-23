    foreach (var custLogin in custLoginHist)
    {
        eCommSecurityFactory oSecFactory = new eCommSecurityFactory();
        if (oCust.CustHash == oSecFactory.CreateHash(custLogin.CustSalt, custLogin.CustHash))
        {
            //Password has been used before;
            return false;
        }
        else
        {
            // Valid password;
            return true;
        }
    }
