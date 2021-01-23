    interface IService 
    {
        void Method(); 
    }
    class ServiceImpl : IService // one of many implementations
    {
        [CustomRole("Admin")]
        public void Method() { ... } 
    }
    class ServiceChecker : IService // one of many implementations
    {
        IService m_svc;
        public ServiceChecker(IService wrapped) { m_svc = wrapped; }
        
        public void Method() 
        {
            var mi = m_svc.GetType().GetMethod("Method");
            if(mi.IsDefined(typeof(CustomRoleAttribute), true)
            {
                CustomRoleAttribute attr =  (CustomRoleAttribute)mi.GetCustomAttributes(typeof(CustomRoleAttribute), true)[0];
                if(!attr.Role.Equals( GetCurrentUserRole() ) // depends on where you get user data from
                {
                    throw new SecurityException("Access denied");
                }
            }
            m_svc.Method(); 
        } 
    }
    // the client code
    IService svc = new ServiceChecker(new ServiceImpl());
    svc.Method();
