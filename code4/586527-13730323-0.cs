    class Corporation
    {
       public int Id {get;set;}
       public virtual List<Phone> Phones {get;set;}
    }
    class Phone
    {
       public int Id {get;set;}
       public virtual Corporation Corp {get;set;}
    }
