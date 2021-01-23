    using Library = Microsoft.Office.Project.Server.Library;
    class ProjectProxy
    {
        private WbSvcProject.Project projectSvc;
        public ProjectProxy()
        {
            this.projectSvc = new WbSvcProject.Project();
            this.projectSvc.Url = Program.PWAServer + "/_vti_bin/psi/project.asmx";
            this.projectSvc.UseDefaultCredentials = true;
        }
        //ProjectTeamDataSet ds = new ProjectTeamDataSet();
        //ProjectTeamDataSet.ProjectTeamRow row = ds.ProjectTeam.NewProjectTeamRow();
        //row.PROJ_UID = projectGuid;
        //row.RES_UID = resourceGuid;
        //row.NEW_RES_UID = resourceGuid;
        //ds.ProjectTeam.AddProjectTeamRow(row);
        public void QueueUpdateProjectTeam(Guid sessionUid, Guid projectUid, ProjectTeamDataSet dataset)
        {
            Guid jobUid = Guid.NewGuid();
            try
            {
                this.projectSvc.QueueUpdateProjectTeam(jobUid, sessionUid, projectUid, dataset);
            }
            catch (SoapException soapException)
            {
                List<string> queueErrors = new List<string>();
                queueErrors.Add(soapException.Message);
                Library.PSClientError clientError = new Library.PSClientError(soapException);
                Library.PSErrorInfo[] errors = clientError.GetAllErrors();
                foreach (Library.PSErrorInfo error in errors)
                {
                    queueErrors.Add(error.ErrId.ToString());
                }
            }
        }
    }
