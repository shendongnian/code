    public static T GetInHeaderProperty<T>() where T : ISomeType, new()
    {
        T result = new T();
        result.CompanyId = "Test";
        result.UserId = "Test";
        result.Password = "Test";
        result.MessageId = " ";
        return result;
    }
