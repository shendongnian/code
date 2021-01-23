        private void PlanPackageBegin(object sender, PlanPackageBeginEventArgs e)
        {         
            if (e.PackageId.Equals("Setup1.msi", StringComparison.Ordinal))
            {
                this.model.LogMessage("PlanPackageBegin Setup1 : " + e.State);
                string IsSetup1= this.model.BootstrapperApplication.Engine.StringVariables["chkSetup1"];
                if (IsSetup1== "True")
                {
                    e.State = RequestState.Present;
                }
                else
                {
                    e.State = RequestState.Absent;
                }
                this.model.LogMessage("PlanPackageBegin Setup1 : " + e.State);
               
            }
            if (e.PackageId.Equals("Setup2.msi", StringComparison.Ordinal))
            {
                this.model.LogMessage("PlanPackageBegin Setup2 : " + e.State);
                
                string IsSetup2= this.model.BootstrapperApplication.Engine.StringVariables["chkSetup2"];
                if (IsSetup2== "True")
                {
                    e.State = RequestState.Present;
                }
                else
                {
                    e.State = RequestState.Absent;
                }
                this.model.LogMessage("PlanPackageBegin Setup2 : " + e.State);
            }
          }
