    [OperationContract]
    [WebGet(ResponseFormat = WebMessageFormat.Json)]
    public CommentList GetComments()
    {
    	Comments oComment1 = new Comments();
    	oComment1.Title = "Your Title";
    	oComment1.Author = "Your Date";
    
    	Comments oComment2 = new Comments();
    	oComment2.Title = "Your Title";
    	oComment2.Author = "Your Date";
    
    	Comments oComment2 = new Comments();
    	oComment3.Title = "Your Title";
    	oComment3.Author = "Your Date";
    
    	CommentList oCommentList = new CommentList();
    	oCommentList.Comment.Add(oComment1);
    	oCommentList.Comment.Add(oComment2);
    	oCommentList.Comment.Add(oComment3);
    
    	return oCommentList;
    }
