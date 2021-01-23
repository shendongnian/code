    public int CommentsDelete(Nullable<global::System.Int32> p_CommentId)
            {
                ObjectParameter p_CommentIdParameter;
                if (p_CommentId.HasValue)
                {
                    p_CommentIdParameter = new ObjectParameter("TCommentId", p_CommentId);
                }
                else
                {
                    p_CommentIdParameter = new ObjectParameter("TCommentId", typeof    (global::System.Int32));
                }
    
                return base.ExecuteFunction("RecursiveCommentsDelete", p_CommentIdParameter);
            }
 
