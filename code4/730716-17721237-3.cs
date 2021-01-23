    /// <summary>
    /// Must be called before the grid is being modified
    /// We also call it inside every method so that if the user forgets to call it is no big deal
    /// For this reason the calls can be nested.
    /// So if the user forgets to make the call it is safe
    /// and if the user does not forget he/she gets the full speed benefits..
    /// </summary>
    public void BeginUpdate()
    {
      if (m_ViewLockCount == 0)
        m_ViewLock = new CWorkbookViewLockHelper(this.Workbook);
      m_ViewLockCount++;
    }
    /// <summary>
    /// Must be called after the grid has being modified
    /// </summary>
    public void EndUpdate()
    {
      m_ViewLockCount--;
      if (m_ViewLockCount <= 0)
      {
        m_ViewLock.Dispose();
        m_ViewLock = null;
      }
    }
