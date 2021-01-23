    using System;
    using NHibernate;
    using NHibernate.Type;
    using System.Threading;
    using System.Security;
    
    namespace bla
    {
        /// <summary>
        /// NHibernate Interceptor that stores audit information (idlogin and datetime.now) on every save and update
        /// </summary>
        public class AuditInterceptor : EmptyInterceptor
        {
    
            private int updates;
            private int creates;
            private int loads;
            private ISession session;
    
            public override void OnDelete(object entity,
                                          object id,
                                          object[] state,
                                          string[] propertyNames,
                                          IType[] types)
            {
                // do nothing
            }
    
            public override bool OnFlushDirty(object obj, object id, object[] currentState, object[] previousState, string[] propertyNames, IType[] types)
            {
                bool found = false;
                if (obj is Entity)
                {
                    updates++;
                    for (int i = 0; i < propertyNames.Length; i++)
                    {
                        if ("dtlastchanged".Equals(propertyNames[i].ToLower()))
                        {
                            currentState[i] = DateTime.Now;
                            found = true;
                        }
                        if ("lastchangedby".Equals(propertyNames[i].ToLower()))
                        {
                            currentState[i] = this.session.Get<Login>(IdLogin, LockMode.None);
                            found = true;
                        }
                    }
                }
                return found;
            }
    
            public override bool OnLoad(object obj, object id, object[] state, string[] propertyNames, IType[] types)
            {
                if (obj is Entity)
                {
                    loads++;
                }
                return false;
            }
    
            public override bool OnSave(object entity,
                                        object id,
            object[] state,
            string[] propertyNames,
            IType[] types)
            {
                bool found = false;
                if (entity is Entity)
                {
                    creates++;
                    for (int i = 0; i < propertyNames.Length; i++)
                    {
                        if ("dtlastchanged".Equals(propertyNames[i].ToLower()))
                        {
                            state[i] = DateTime.Now;
                            found = true;
                        }
                        if ("lastchangedby".Equals(propertyNames[i].ToLower()) && !(entity is Login && (entity as Login).IsInVerification))
                        {
                            state[i] = this.session.Get<Login>(IdLogin, LockMode.None);
                            found = true;
                        }
                    }
                }
                return found;
            }
    
            public override void AfterTransactionCompletion(ITransaction tx)
            {
                //if (tx.WasCommitted)
                //{
                //    System.Console.WriteLine("Creations: " + creates + ", Updates: " + updates, "Loads: " + loads);
                //}
                updates = 0;
                creates = 0;
                loads = 0;
            }
    
            public override void SetSession(ISession session)
            {
                this.session = session;
                base.SetSession(session);
            }
    
            protected long IdLogin
            {
                get
                {
    				return (Thread.CurrentPrincipal.Identity as CustomIdentity).IdLogin; // or something else that holds the id of the current logged in user
                }
            }
        }
    }
