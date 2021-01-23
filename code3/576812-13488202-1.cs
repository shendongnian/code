    public void UpdateProduct(Product product) {
      var modifiedStateEntries = Context.ObjectStateManager.GetObjectStateEntries(EntityState.Modified);
        foreach (var entry in modifiedStateEntries) {
          var comment = entry.Entity as Comment;
          if (comment != null && comment.Product == null) {
            Context.DeleteObject(comment);
          }
        }
     }
