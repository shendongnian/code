    public class ISINameMasterRecord : EXBase
        {
            public virtual int NM_ID_NUM { get; set; }
            public virtual String NM_EMAIL_ADDRESS { get; set; }
            public virtual String NM_MOBILE_PHONE { get; set; }
    
            public virtual ISILHPAddress LHP
            {
                get { return Addresses != null && Addresses.Any() ? Addresses[0] : null; }
                set
                {
                    if (Addresses == null)
                        Addresses = new List<ISILHPAddress>();
    
                    if (Addresses.Any())
                        Addresses[0] = value;
                    else
                        Addresses.Add(value);
                }
            }
    
            //for mapping purposes
            protected virtual IList<ISILHPAddress> Addresses { get; set; }
    
    
            public ISINameMasterRecord()
            {
    
            }
        }
