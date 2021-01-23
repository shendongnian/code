    using (TransactionScope scope = new TransactionScope())
    {
        // Save changes but maintain context1 current state.
        context1.SaveChanges(SaveOptions.DetectChangesBeforeSave);
        // Save changes but maintain context2 current state.
        context2.SaveChanges(SaveOptions.DetectChangesBeforeSave);
        // Commit succeeded since we got here, then completes the transaction.
        scope.Complete();
        // Now it is safe to update context state.
        context1.AcceptAllChanges();
        context2.AcceptAllChanges();
    }
