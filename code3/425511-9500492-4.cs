    public void LoadPeople()
    {
        this.People.Clear();
    
        foreach( Person person in SystemContext.People )
        {
            this.People.Add( person );
        }
    }
