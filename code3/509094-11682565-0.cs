     private void CreateComments(int ? postId, int ? cid)
          {          
                int? id = cid;
                
            var replies = new List<Comment>();
            if (postId.HasValue())
            {
                  var BlogPost = context.Posts.Single(p=>p.Id == postId.Value);
                  replies = BlogPost.Comments;  
            }
            else
            {
                replies = context.Comments.Where(c=>c.CommentParent == id);         
            }  
            
            foreach (Comment reply in replies)
                {     
                    //logic for creating your html tag   
                    CreateComments(null,reply.id);
                }   
         }
