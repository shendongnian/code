    public static async Task<object> Deserialize(Model model, Stream stream,
                                                 Type type)
    {
        return model.Deserialize(stream, null, type);
    }
