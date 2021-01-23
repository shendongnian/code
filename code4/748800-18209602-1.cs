    public string Property1
    {
        set 
        { 
           this.field1 = value; 
           CommonValidate(c => c.Property1, value);
        }
     }
