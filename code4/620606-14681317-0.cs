    public void NullSafeSet(IDbCommand cmd, object value, int index)
    {
        var ints = value as IntArray;
        if(ints != null && ints.Items != null)
        {
          NHibernate.NHibernateUtil.StringClob.NullSafeSet(cmd, string.Join(", ", ints.Items), index);
        }
    }
