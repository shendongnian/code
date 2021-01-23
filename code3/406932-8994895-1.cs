    public static class EntityUtil
    {
       public enum Sequence
       {
          TPM_PROJECTVERSIONDOCS_PK_SEQ
       };
    
       public static decimal GetNextSequence(this TPMEntities context, Sequence sequence)
       {
          string sql = String.Format("select {0}.nextval from dual", sequence.ToString());
          var testId = context.ExecuteStoreQuery<decimal>(sql);
    
          return testId.First();
       }
    }
