    [Button("submit1")]
    public string Post(string x, int y, FormDataCollection formData)
    {
        return "Post 1";
    }
    [Button("submit2")]
    public string Post(string x, int y)
    {
        return "Post 2";
    }
