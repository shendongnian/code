        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(CallContext))
            {
                var context = (CallContext)obj;
                if (Country != null)
                {
                    if (Country.ToLower() != context.Country.ToLower())
                        return false;
                }
                if (Store != context.Store)
                    return false;
                return true;
            }
            return false;
        }
