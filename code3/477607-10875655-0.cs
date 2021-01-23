    public enum MyOption
    {
        Option1,
        Option2,
        Option3,
    }
    public void MyMethod(MyOption option)
    {
        switch (option)
        {
            case MyOption.Option1:
                // do stuff
                return;
            case MyOption.Option2:
                // do stuff
                return;
            case MyOption.Option3:
                // do stuff
                return;
        }
    }
