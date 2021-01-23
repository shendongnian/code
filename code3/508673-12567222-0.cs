    private Panel GetPanelToBeLoaded(int investmentTypeId)
            {
                System.Web.UI.Control userControl = GetInvestmentDetailsUserControlUrl();
                **userControl.ID = investmentTypeId.ToString();**
                Panel panel = new Panel();
                panel.Controls.Add(userControl);
                projectInvestmentDetailsControl = (IProjectInvestmentDetailsControl)userControl;
                projectInvestmentDetailsControl.InvestmentTypeID = investmentTypeId;
                projectInvestmentDetailsControl.UserContext = userContext;
                projectInvestmentDetailsControl.PlanningWizardDataManager = PlanningWizardDataManager;
                projectInvestmentDetailsControl.PlanningServiceWrapper = PlanningServiceWrapper;
                
                return panel;
            }` 
