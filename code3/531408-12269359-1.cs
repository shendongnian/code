    void LoadPeople(GetPlayersEventArgs e)
    {
        _People.Clear();
    
        foreach (Player Person in e.Result)
        {
            Player newPerson = new Player();
            ...
            this.People.Add(newPerson);
        }
    
        this.SetUnBusy();
    }
