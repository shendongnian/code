    Person p = new Person();
    p.UserName = model.UserName;
    ((PeronRepository)repository).Add(p);
    ((PerssonRepository)repository).Save(p);
    WebSecurity.CreateAccount(model.UserName, model.Password);
