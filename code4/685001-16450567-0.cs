    public int GenerateNumber()
    {
        Random r = new Randon();
        int num = r.Next(1000);
    
        //Psuedo-code
        if(num is in table)
         num = GenerateNumber(); //num = added.
    
        return num;
    }
