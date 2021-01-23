    private bool SaveAll()
        {
    ...
    ..
    ..
        if (this.mDesTemp != null)
        {       
             try {
                 fDenemeProxy dnm = new fDenemeProxy();      
                 dnm.SaveThisCustomer(1234,"D",true);
             } catch (FileNotFoundException e) {
                 // deal with the new situation !
             }
        }
    ...
    ..
    return;    
    }
