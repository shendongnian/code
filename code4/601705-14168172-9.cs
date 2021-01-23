    List<List<string>> users = new List<List<string>>();
    List<string> user = new List<string>();
    StringBuilder potato = new StringBuilder();
    int i=0;
    bool escaped=false;
    while (i<userDB.Length)
    {
        if (userDB[i] == '\\' && !escaped)
        {
            escaped = true;
        }
        else if (userDB[i] == ':' && !escaped)
        {
             user.Add(potato.ToString());
             potato.Clear();
        }
        else if (userDB[i] == '-' && !escaped)
        {
             user.Add(potato.ToString());
             potato.Clear();
             users.Add(user);
             user = new List<string>();
        }
        else
        {
        	potato.Append(userDB[i]);
	        escaped = false;
        }
    }
    
