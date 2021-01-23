    private void SomeMethod(System.Type type)
    {
        if(!typeof(U).IsAssignableFrom(type)) {
            throw new ArgumentException("type must extend U!");
    }
