    [OperationContract]
    [WebGet(ResponseFormat = WebMessageFormat.Json)]
    public Comments[] GetComments()
    {
        Comments oComment1 = new Comments();
        oComment1.Title = "AMaking hay when the sun shines";
        oComment1.Author = "Plan_A";
        oComment1.CommentText = "AI like hay almost as much as I like sun. Just joking";
        Comments oComment2 = new Comments();
        oComment2.Title = "Making hay when the sun shines";
        oComment2.Author = "Plan_B";
        oComment2.CommentText = "I like hay almost as much as I like sun. Just joking";
        return new Comments[]{oComment1, oComment2};
    }
