    public static void FillObject<T>(T [] obs, DataTable dt) where T: new
    {
        //...
        obs[j] = new T();
    }
