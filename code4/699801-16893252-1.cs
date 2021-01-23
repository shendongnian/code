    class KLAService : IKLAService
    {
        CentralLogic m_centralLogic;
    
        public KLAService() 
        {
           m_centralLogic = CentralLogic.Instance;
           ....
        }
    }
