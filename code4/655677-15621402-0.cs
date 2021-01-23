    public MyError(int id, string message)
    {
        this.id = id;
        this.message = message;
    }
    private readonly int id;
    private readonly string message;
    public int Id { get { return id; } }
    public string Message { get { return message; } }
