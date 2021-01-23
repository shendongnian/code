            if (TEntity is LogicalStorageEntity)
            {
                return _context.Set<TEntity>
                    .Where(x => /* filter by x.Deleted */)
                    .Where(x => /* filter by x.StorageId */)
                    .ToArray();
            }
    
            if (TEntity is ArchiveEntity)
            {
                return _context.Set<TEntity>
                    .Where(x => /* filter by x.Deleted */)
                    .ToArray();
            }
