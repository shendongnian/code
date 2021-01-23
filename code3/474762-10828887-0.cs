    class EloComServer : DynamicObject, IDisposable
    {
        private Type javaClientType;
        private object elo;
        public EloComServer()
        {
            javaClientType = Type.GetTypeFromProgID("jniwrapper.elocomserver");
            elo = Activator.CreateInstance(javaClientType);
        }
        ~EloComServer()
        {
            this.Dispose();
        }
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            try
            {
                result = javaClientType.InvokeMember(binder.Name,
                        BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Instance,
                        null, elo, args);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            try
            {
                javaClientType.InvokeMember(binder.Name,
                        BindingFlags.SetProperty | BindingFlags.Public | BindingFlags.Instance,
                        null, elo, new object[] { value });
                return true;
            }
            catch
            {
                return false;
            }
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            try
            {
                result = javaClientType.InvokeMember(binder.Name,
                        BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance,
                        null, elo, new object[0]);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }
        #region IDisposable Members
        public void Dispose()
        {
            if (this.elo != null)
            {
                Marshal.ReleaseComObject(elo); 
            }
        }
        #endregion
    }
