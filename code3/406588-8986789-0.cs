    public static T GetInHeaderProperty<T>(Func<T> createObjFunc)
    {
        T result = createObjFunc();
        dynamic resultAsDynamic = result as dynamic;
        resultAsDynamic.CompanyId = "Test";
        resultAsDynamic.UserId = "Test";
        resultAsDynamic.Password = "Test";
        resultAsDynamic.MessageId = " ";
        result = (T)resultAsDynamic;
        return result;
    }
