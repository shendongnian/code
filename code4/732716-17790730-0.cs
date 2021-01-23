    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Threading;
    using System.Web.Mvc;
    using WebMatrix.WebData;
    using SimpleLogin_System_04.Models;
    namespace SimpleLogin_System_04.Filters
    {
    public class InitializeSimpleMembership : ActionFilterAttribute
    {
        public InitializeSimpleMembership()
        {
            try
            {
                if (!WebSecurity.Initialized)
                {
                    WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
            }
        }
    }
