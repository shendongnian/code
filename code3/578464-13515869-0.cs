        private void CheckIfDifferent(DbEntityEntry entry)
        {
            if (entry.State != EntityState.Modified) 
                return;
            if (entry.OriginalValues.PropertyNames.Any(propertyName => !entry.OriginalValues[propertyName].Equals(entry.CurrentValues[propertyName])))
                return;
           (this.dbContext as IObjectContextAdapter).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity).ChangeState(EntityState.Unchanged);
        }
