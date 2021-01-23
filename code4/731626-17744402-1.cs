    public List<int> Call<TEnum>(Type enumType, TEnum enumValue) 
    {
        if(!enumType.IsAssignableFrom(typeof(TEnum)))
            throw new ArgumentException();
        // Something
    }
