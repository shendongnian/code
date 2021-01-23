    public void DeleteTerm(string term, string Server)
    {
       if(Server == "SQL")
        { 
             WebService1 ws = new WebService1();
             ws.deleteTerm(term);
        }
        if(Server == "DB2")
        { 
             WebServiceDB2 ws = new WebServiceDB2();
             ws.deleteTerm(term);
        } 
    }
