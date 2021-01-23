    // helper class
    public static class CommonCrm
    {        
        public static readonly CrmConnection crmConnection = null;
        public static readonly OrganizationService crmService = null;
        public static readonly CrmOrganizationServiceContext crmContext = null;
        static CommonCrm()
        {
            try
            {
                CommonCrm.crmConnection = new CrmConnection("Crm");
    // "Crm" is a connection string which goes like this in Web.config:
    //<connectionStrings>
    //    <add name="Crm" connectionString="Url=http://orgUrl; Domain=X; Username=Y; Password=Z;" />
    //</connectionStrings>
                CommonCrm.crmService = new OrganizationService(crmConnection);
                CommonCrm.crmContext = new CrmOrganizationServiceContext(crmService);
            }
            catch (Exception ex)
            {
                //Log exception (code removed)
                throw;
            }
        }
    }
    public class CrmUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userId { get; set; }
        public Guid userGuid { get; set; }
        public Guid buId { get; set; }
        public static List<CrmUser> GetAllCrmUsers()
        {
            List<CrmUser> CrmUsers = new List<CrmUser>();
            try
            {
                ColumnSet colsPrincipal = new ColumnSet("lastname", "firstname", "domainname", "systemuserid", "businessunitid");
                QueryExpression queryPrincipal = new QueryExpression();
                queryPrincipal.EntityName = "systemuser";
                queryPrincipal.ColumnSet = colsPrincipal;
        
                var myAccounts = CommonCrm.crmContext.RetrieveMultiple(queryPrincipal);
        
                foreach (var myEntity in myAccounts.Entities)
                {
                    //create new crm users and add it to the list
                    CrmUser thisOne = new CrmUser();
        
                    thisOne.firstName = myEntity.GetAttributeValue<string>("firstname");
                    thisOne.lastName = myEntity.GetAttributeValue<string>("name");
                    thisOne.userId = myEntity.GetAttributeValue<string>("domainname");
                    thisOne.userGuid = myEntity.GetAttributeValue<Guid>("systemuserid");
                    thisOne.buId = myEntity.GetAttributeValue<EntityReference>("businessunitid").Id;
                    // and so on and so forth...         
                    CrmUsers.Add(thisOne);
                }
            }
            catch (Exception ex)
            {
                CrmUser thisOne = new CrmUser();
                thisOne.firstName = "Crap there was an error";
                thisOne.lastName = ex.ToString();
                CrmUsers.Add(thisOne);
            }
        
            return CrmUsers;
        }
    }
