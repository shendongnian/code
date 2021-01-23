    public object UnproxyAndReassociate(object maybeProxy)
    {
        var proxy = maybeProxy as INHibernateProxy;
        if (proxy != null)
        {
            ILazyInitializer li = proxy.HibernateLazyInitializer;
            ReassociateProxy(li, proxy);
            return li.GetImplementation(); //initialize + unwrap the object 
        }
        return maybeProxy;
    }
