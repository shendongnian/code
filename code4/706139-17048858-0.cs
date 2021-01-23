    public class ScenarioPermissions : BusinessListBase<ScenarioPermissions, ScenarioPermission>
    {
        public static ScenarioPermissions NewPermissions()
        {
            return DataPortal.Create<ScenarioPermissions>();
        }
 
        public static ScenarioPermissions GetUsersByScenario(Scenario scenario)
        {
            return DataPortal.FetchChild<ScenarioPermissions>(scenario);
        }
 
        private void Child_Fetch(Scenario obj)
        {
            RaiseListChangedEvents = false;
            using (var ctx = DbContextManager<DatabaseContext>.GetManager())
            {
                var context = ctx.DbContext;
                var scenario = context.Scenarios.Where(s => s.Id == obj.Id).FirstOrDefault();
                if (scenario != null)
                {
                    foreach (var item in scenario.Users)
                    {
                        this.Add(ScenarioPermission.GetPermission(scenario.Id, item.Id));
                    }
                }
            }
            RaiseListChangedEvents = true;
        }
    }
    public class ScenarioPermission : BusinessBase<ScenarioPermission>
    {
        public static ScenarioPermission GetPermission(Guid scenarioID, int userID)
        {
           return DataPortal.FetchChild<ScenarioPermission>(scenarioID, userID);
        }
        private void Child_Fetch(Guid scenarioID, int userID)
        {
            LoadProperty(m_ScenarioID, scenarioID);
            LoadProperty(m_UserID, userID);
        }
    }
