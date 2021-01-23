    class A 
    {     
        //should only be called by Admins**     
        [PrincipalPermission(SecurityAction.Demand, Role="Admin")] 
        public void Method1() 
        { 
        }      
        //should only be called by Admins and PM's**      
        [PrincipalPermission(SecurityAction.Demand, Role="Admin")] 
        [PrincipalPermission(SecurityAction.Demand, Role="PM")] 
        public void Method2() 
        { 
        } 
    } 
