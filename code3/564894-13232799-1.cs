    public Workbook this[int iIndex]
    {
     get
     {
      int c = 0;
      foreach (Workbook wb in this)
      {
       if (c == iIndex)
         return wb;
       c++;
      }
      return null;
     }
    }
    
    // ...
    // The Workbook object represents the COM object Excel.Workbook
    IEnumerator<Workbook> IEnumerable<Workbook>.GetEnumerator()
    {
     foreach (var obj in (IEnumerable)m_COMObject)
      yield return obj == null ? null : new Workbook(obj, this);
    }
