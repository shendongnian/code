    private sealed class DataRowTree : RBTree<DataRow>
    {
      internal DataRowTree()
        : base(TreeAccessMethod.INDEX_ONLY)
      {
      }
      protected override int CompareNode(DataRow record1, DataRow record2)
      {
        throw ExceptionBuilder.InternalRBTreeError(RBTreeError.CompareNodeInDataRowTree);
      }
      protected override int CompareSateliteTreeNode(DataRow record1, DataRow record2)
      {
        throw ExceptionBuilder.InternalRBTreeError(RBTreeError.CompareSateliteTreeNodeInDataRowTree);
      }
    }
