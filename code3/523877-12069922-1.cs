    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ServiceModel;
    using pageengine.services.entities.account;
    using pageengine.services;
    namespace pageengine.clients.accounts
    {
        public class AccountsRepository : RepositoryBase<IAccounts>, IDisposable
        {
            #region CTOR
            public AccountsRepository()
            {
                this.roleName = "EntitiesRole";      // Name of the role my service is on
                this.endpointName = "HttpInternal";  // Name of the endpoint configured on that role. Can be internal or input, tcp or http.
                this.serviceName = "Accounts.svc";   // Name of my service.
            }
            #endregion
        }
    }
