    private static MyModel Function()
    {
        if (ok)
        {
            return new MyModel
            {
                Success = true,
                Id = UserId,
            };
        }
        return new MyModel
        {
            Success = false,
        };
    }
