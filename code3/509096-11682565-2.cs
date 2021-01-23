     private void CreateComments(int ? postId, int ? cid)
          {          
            int? id = cid;                
            var replies = new List<Comment>();
            if (postId.HasValue())
            {
                  var BlogPost = context.Posts.Single(p=>p.Id == postId.Value);
                  replies = BlogPost.Comments.Where(c=>c.CommentParent == null);  
            }
            else
            {
                replies = context.Comments.Where(c=>c.CommentParent == id);         
            }  
            
            int level = 0;
            Comment tmp = new Comment();
            foreach (Comment reply in replies)
                {     
                    tmp = reply;
                    while(tmp.CommentParent != null){
                          level++;
                          tmp = context.Comments.Single(c=>c.Id == tmp.CommentParent);
                    }
                    //logic for creating your html tag 
                    //you can use "level" to leave appropriate indent back to your comment.
                    CreateComments(null,reply.id);
                }   
         }
