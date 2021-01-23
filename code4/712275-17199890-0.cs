    public dynamic MyToObject(B b, C c)
    {
        return new
        {
            BUserName = b.UserName,
            BPassword = b.PassWord,
            CUserName = c.UserName,
            CPassword = c.PassWord
        }
    }
