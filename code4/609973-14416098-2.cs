        // SavingChanges event handler. 
        private void context_SavingChanges(object sender, EventArgs e) {
            ObjectContext objectContext = sender as ObjectContext;
            if (objectContext != null) {
                foreach (ObjectStateEntry entry in objectContext.ObjectStateManager
                                .GetObjectStateEntries(EntityState.Added | EntityState.Modified | EntityState.Deleted)
                                .Where(et => et.Entity.GetType().Equals(typeof(Comment)))) {
                    
                    Comment comment = entry.Entity as Comment;
                    Comment_Audit audit = new Comment_Audit {
                        BodyText = comment.BodyText,
                        Commentor = comment.Commentor,
                        ..
                        ..
                        ChangedAt = DateTime.Now,
                        ChangeType = entry.State.ToString()
                    };
                    StackOverflowEntities.Set<Comment_Audit>().Add(audit);
                   
                }
            }
        }
