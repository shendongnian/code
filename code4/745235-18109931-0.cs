    public void Login(string user, string password, int entityID)
    {
        if(CheckLoginData(user, password))
        {
             ChangeDatabase(entity_id);
        }
    }
