    public ActionResult Create(FormCollection collection) {
      string commentText = collection["CommentText"];
      Post p = ... ; // Not familiar with EF
      p.Comments.Add(new Comment(commentText));
      p.Save(); // ActiveRecord style, not sure about EF
    }
