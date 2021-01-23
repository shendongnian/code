    private bool inCheckList;
    private void OnOCXEvent(object objToAdd)
    {
       lock(m_ObjectList)
       {
          if (inCheckList)
          {
             throw new Exception("Look at this stack trace!");
          }
          m_ObjectList.Add(objToAdd);
       }
    }
    private void CheckList()
    {
       lock(m_ObjectList)
       {
          inCheckList = true;
          foreach(object obj in m_ObjectList)
          {
             ...
          }
          inCheckList = false; // Put this in a finally block if you really want
       }
    }
