    public void OutsiderMethod(Type T)
    {
        Action action = OutsiderMethodHelper<object>;
        action.Method.GetGenericMethodDefinition().MakeGenericMethod(T).Invoke(null, null);
    }
