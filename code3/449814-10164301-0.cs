    private List<string> getChats()
    {
        // Unless you've got one somewhere else...
        Skype skype = new Skype();
        List<string> r = new List<string>();
  
        foreach (Chat c in skype.Chats)
        {
             // Skype generates invalid chats...
             try { r.Add(c.Name); } catch (Exception) {}
        }
        return r;
    }
