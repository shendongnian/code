    private void InitMessage()
    {
        Message = String.Format(Message,
                                new object[]{FirstValue}.Concat(_parameters).ToArray());
    }
