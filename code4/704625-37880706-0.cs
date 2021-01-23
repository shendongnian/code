    int Validate(saveobj obje)
    {    
        // here I do my validations 
        return 0;
    }
    
    public string sendingObj(saveobj obje)
    {
           int result=0;
           Task.Run(()=>
           {
               result = Validate(obje);
               if(result != 0)
           });
        
        return result;
    }
