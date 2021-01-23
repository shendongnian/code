    public void SomeMethod()
    {
        C c = new C();
        int i = c.Id; // works
        int j = c.protectedId; // does NOT work
        int k = c.privateId; // does NOT work
    }
