    public static T GetInHeaderProperty<T>() where T : new()
    {
        dynamic result = new T();
        result.CompanyId = "Test";
        result.UserId = "Test";
        result.Password = "Test";
        result.MessageId = " ";
        return (T)result;
    }
