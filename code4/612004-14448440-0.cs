    public int IndexEntities<TEntity>(DirectoryInfo indexLocation, IEnumerable<TEntity> entities, Func<TEntity, Document> converter)
    {
        using (var indexer = new IndexWriterWrapper(indexLocation)) {
            int indexCount = 0;
            foreach (TEntity entity in entities) {
                indexer.Writer.AddDocument(converter(entity));
                indexCount++;
            }
            return indexCount;
        }
    }
