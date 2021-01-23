    // some example in related to your question and the strategy pattern provided at the link
    public static string DoThis(string pci)
    {
     var a = GetAByPCI(string pci);
     if(a == 1)
         return new I();
     else
         return null;
    }
    // put this anywhere else
    public static string DoThat(string pci)
    {
       var a = GetAByPCI(string pci);
       
       if(a == 2)
         return new O();
       else
         return null;
    }
