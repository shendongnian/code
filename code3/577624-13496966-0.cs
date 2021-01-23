    string star = "";
    for (int i = 0; i < Math.Min(15, Model.orgInternalcontact.User.Password.Length); i++)
    {
         string mem = "*";
         star = star + mem;
    }
