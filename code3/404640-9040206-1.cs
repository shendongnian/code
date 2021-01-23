    while (odbcr2.Read()) 
    { 
        storenumber = odbcr2["chstor"].ToString(); 
        totalstorecartons = odbcr2["totalstorecartons"].ToString(); 
     
     
        //Create Store Record - Type "B" 
        w.WriteLine(constantB + deliverycarrierSCAC + clientroute + businesscode + storenumber + clientbolnumber + terminalcode + deliverydays + deliverystarttime + deliveryendtime + carrierpro + expecteddeliverydate); 
     
        OdbcCommand getcartons = new OdbcCommand("select chcasn, chstor, chacwt from wm242basd.chcart00 where chldno = '0010585567' and chstor = :storeNumber", odbccon); 
        getcartons.AddParameter("storeNumber", storenumber);
        OdbcDataReader odbcr = getcartons.ExecuteReader(); 
        while (odbcr.Read()) 
        { 
            cartonnumber = odbcr["chcasn"].ToString() + "                 "; 
            storenumber = odbcr["chstor"].ToString() + "  "; 
            weightlbs = odbcr["chacwt"].ToString(); 
     
     
            //Create Store Record - Type "C" 
            w.WriteLine(constantC + cartonnumber + weightlbs + cubicfeet + conveyable + specialhandling + cartonvalue + cartonretail + units + palletnumber); 
        } 
     
        //Create Store Record - Type "D" 
        w.WriteLine(constantD + totalstorecartons + totalstoreweight + totalstorecubicfeet); 
    } 
