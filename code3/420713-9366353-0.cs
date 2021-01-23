    int[] userid = new int[usernames.length];
    i=0;
        foreach(string username in usernames)
        {
            User user = AuthRepository.GetUser(username);
    
            userid[i] = user.ID;
            i++;
        }
    int[] roleid = new int[...];
    i = 0;
