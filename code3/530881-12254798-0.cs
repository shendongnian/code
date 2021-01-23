     var comment = new Comment();
     using (var db = new LinqEntityDataContext())
                {               
                    comment.CommentBy = GlobalVariables.User.ID;
                    comment.OutPutMessage = commentText.Trim();
                    comment.PhotoID = int.Parse(pictureID);
                    comment.CommentDate = DateTime.Now;
                    db.Comments.InsertOnSubmit(comment);
                    db.SubmitChanges();              
                }
      return comment;
