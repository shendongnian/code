    public class JAccount
    {
        private AcountType _type;
    
        public JAccount(AcountType type)
        {
            _type = type;
        }
    
        public virtual long Id { get; private set; }
        //some properties
        public virtual JProfile Profile { get; set; }
    
        public void Register()
        {
            _type.Register(this);
        }
    }
    
    // in JAccountMap
        References(Reveal.Member<JAccount>("_type")).Access.Field().Not.LazyLoad();
        // or
        Map(Reveal.Member<JAccount>("_type"), "type").CustomType<AccountTypeToStringUserType>();
