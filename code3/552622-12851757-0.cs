    public void Insert<TableType>(int foreignKeyId, string columnName,
        TList<TableType> entity, TransactionManager transactionManager) {
        entity.ForEach(pca => {
            pca.GetType().GetProperty(columnName).SetValue(pca, foreignKeyId, null);
            pca.EntityState = EntityState.Added;
            _provider.payment.Insert(transactionManager, pca);
        });
    }
