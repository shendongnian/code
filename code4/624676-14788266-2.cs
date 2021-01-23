    public event EventHandler<ProjectDetailsArgs> ProjectDetailsSubmitted;
        public class ProjectDetails: EventArgs
        {
            public string projectReference{ get; set; }
            public string projectNo{get;set;}
            //you can add more prop.s here
        }
    
    On your Ok button click event add 
    
    if (ProjectDetailsSubmitted != null)
                    {
                        ProjectDetailsArgs argss = new ProjectDetailsArgs();
                        argss.projectReference = projectRefrencetTextBox.Text;
                        argss.projectNo = projectNoTextBox.Text;
                        ProjectDetailsSubmitted(null, argss);
                    }
