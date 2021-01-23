            /// <summary>
            /// Detach any existing rows with the same keys (if necessary), then attach to this object using the "*" ETag
            /// </summary>
            /// <param name="newEntity"></param>
            protected virtual void SafeAttach(TableServiceEntity newEntity)
            {
                TableServiceEntity entity = GetExistingRow(newEntity.PartitionKey, newEntity.RowKey);
                if(entity != null)
                {
                    base.Detach(entity);
                }
    
                base.AttachTo("MY_TABLE_NAME_GOES_HERE", newEntity, "*");
            }
    
            private TableServiceEntity GetExistingRow(string partitionKey, string rowKey)
            {
                var query = (from e in base.Entities
                             where e.Entity is TableServiceEntity
                             && ((TableServiceEntity)e.Entity).RowKey == rowKey
                             && ((TableServiceEntity)e.Entity).PartitionKey == partitionKey
                             select (TableServiceEntity)e.Entity);
    
                RetrierFunctionResult<TableServiceEntity> r = StorageOperationRetrier.Execute(() =>
                {
                    return query.FirstOrDefault();
                });
    
                return r.Result;
            }
