    public int SaveChanges(string userId)
        {
            int objectsCount;
            List<DbEntityEntry> newEntities = new List<DbEntityEntry>();
            // Get all Added/Deleted/Modified entities (not Unmodified or Detached)
            foreach (var entry in this.ChangeTracker.Entries().Where
                (x => (x.State == System.Data.EntityState.Added) ||
                    (x.State == System.Data.EntityState.Deleted) ||
                    (x.State == System.Data.EntityState.Modified)))
            {
                if (entry.State == System.Data.EntityState.Added)
                {
                    newEntities.Add(entry);
                }
                else
                {
                    // For each changed record, get the audit record entries and add them
                    foreach (AuditLog changeDescription in GetAuditRecordsForEntity(entry, userId))
                    {
                        this.AuditLogs.Add(changeDescription);
                    }
                }
            }
            // Default save changes call to actually save changes to the database
            objectsCount = base.SaveChanges();
            // We don't have recordId for insert statements that's why we need to call this method again.
            foreach (var entry in newEntities)
            {
                // For each changed record, get the audit record entries and add them
                foreach (AuditLog changeDescription in GetAuditRecordsForEntity(entry, userId, true))
                {
                    this.AuditLogs.Add(changeDescription);
                }
                // TODO: Think about performance here. We are calling db twice for one insertion.
                objectsCount += base.SaveChanges();
            }
            return objectsCount;
        }
        #endregion
        #region Helper Methods
        /// <summary>
        /// Helper method to create record description for Audit table based on operation done on dbEntity
        /// - Insert, Delete, Update
        /// </summary>
        /// <param name="dbEntity"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        private List<AuditLog> GetAuditRecordsForEntity(DbEntityEntry dbEntity, string userId, bool insertSpecial = false)
        {
            List<AuditLog> changesCollection = new List<AuditLog>();
            DateTime changeTime = DateTime.Now;
            // Get Entity Type Name.
            string tableName1 = dbEntity.GetTableName();
            // http://stackoverflow.com/questions/2281972/how-to-get-a-list-of-properties-with-a-given-attribute
            // Get primary key value (If we have more than one key column, this will need to be adjusted)
            string primaryKeyName = dbEntity.GetAuditRecordKeyName();
            int primaryKeyId = 0;
            object primaryKeyValue;
            
            if (dbEntity.State == System.Data.EntityState.Added || insertSpecial)
            {
                primaryKeyValue = dbEntity.GetPropertyValue(primaryKeyName, true);
                if(primaryKeyValue != null)
                {
                    Int32.TryParse(primaryKeyValue.ToString(), out primaryKeyId);
                }                
                // For Inserts, just add the whole record
                // If the dbEntity implements IDescribableEntity,
                // use the description from Describe(), otherwise use ToString()
                changesCollection.Add(new AuditLog()
                        {
                            UserId = userId,
                            EventDate = changeTime,
                            EventType = ModelConstants.UPDATE_TYPE_ADD,
                            TableName = tableName1,
                            RecordId = primaryKeyId,  // Again, adjust this if you have a multi-column key
                            ColumnName = "ALL",    // To show all column names have been changed
                            NewValue = (dbEntity.CurrentValues.ToObject() is IAuditableEntity) ?
                                            (dbEntity.CurrentValues.ToObject() as IAuditableEntity).Describe() :
                                            dbEntity.CurrentValues.ToObject().ToString()
                        }
                    );
            }
            else if (dbEntity.State == System.Data.EntityState.Deleted)
            {
                primaryKeyValue = dbEntity.GetPropertyValue(primaryKeyName);
                if (primaryKeyValue != null)
                {
                    Int32.TryParse(primaryKeyValue.ToString(), out primaryKeyId);
                }
                // With deletes use whole record and get description from Describe() or ToString()
                changesCollection.Add(new AuditLog()
                        {
                            UserId = userId,
                            EventDate = changeTime,
                            EventType = ModelConstants.UPDATE_TYPE_DELETE,
                            TableName = tableName1,
                            RecordId = primaryKeyId,
                            ColumnName = "ALL",
                            OriginalValue = (dbEntity.OriginalValues.ToObject() is IAuditableEntity) ?
                                        (dbEntity.OriginalValues.ToObject() as IAuditableEntity).Describe() :
                                        dbEntity.OriginalValues.ToObject().ToString()
                        });
            }
            else if (dbEntity.State == System.Data.EntityState.Modified)
            {
                primaryKeyValue = dbEntity.GetPropertyValue(primaryKeyName);
                if (primaryKeyValue != null)
                {
                    Int32.TryParse(primaryKeyValue.ToString(), out primaryKeyId);
                }
                foreach (string propertyName in dbEntity.OriginalValues.PropertyNames)
                {
                    // For updates, we only want to capture the columns that actually changed
                    if (!object.Equals(dbEntity.OriginalValues.GetValue<object>(propertyName),
                            dbEntity.CurrentValues.GetValue<object>(propertyName)))
                    {
                        changesCollection.Add(new AuditLog()
                        {
                            UserId = userId,
                            EventDate = changeTime,
                            EventType = ModelConstants.UPDATE_TYPE_MODIFY,
                            TableName = tableName1,
                            RecordId = primaryKeyId,
                            ColumnName = propertyName,
                            OriginalValue = dbEntity.OriginalValues.GetValue<object>(propertyName) == null ? null : dbEntity.OriginalValues.GetValue<object>(propertyName).ToString(),
                            NewValue = dbEntity.CurrentValues.GetValue<object>(propertyName) == null ? null : dbEntity.CurrentValues.GetValue<object>(propertyName).ToString()
                        }
                            );
                    }
                }
            }
            // Otherwise, don't do anything, we don't care about Unchanged or Detached entities
            return changesCollection;
        }
