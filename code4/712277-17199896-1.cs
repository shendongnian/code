    public dynamic MyToObject(B b, C c)
    {
        return new { UserNameB = b.UserName, PassWordB = b.PassWord,
            UserNameC = c.UserName, PassWordC = c.PassWord }
    }
