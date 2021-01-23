      public class AdminBaseKey : IDisposable
      {
        private readonly IMSAdminBase_W m_adminBase;
        public readonly int Handle;
    
        public AdminBaseKey(IMSAdminBase_W adminBase, int handle)
        {
          m_adminBase = adminBase;
          Handle = handle;
        }
    
        #region Implementation of IDisposable
    
        public void Dispose()
        {
          m_adminBase.CloseKey(Handle);
        }
    
        #endregion
      }
