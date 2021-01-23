      if (!NHibernateUtil.IsInitialized(object.Lazy_property))
         {
          //open a session
           Class1 temp_object= lSession.Load<Class1>(object.ID);
           if (temp_object.ID == ID)
                Session.Evict(lProgressItemType);
                        
           Session.SaveOrUpdate(this);
           NHibernateUtil.Initialize(ProxyMilestoneList);
          //close session
           }
