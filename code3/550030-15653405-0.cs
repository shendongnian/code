        private TfsTeamProjectCollection GetTfsTeamProjectCollection()
        {
            TeamProjectPicker workitemPicker = new TeamProjectPicker(TeamProjectPickerMode.SingleProject, false, new UICredentialsProvider());
            workitemPicker.AcceptButtonText = "workitemPicker.AcceptButtonText";
            workitemPicker.Text = "workitemPicker.Text";
            workitemPicker.ShowDialog();
            if (workitemPicker.SelectedProjects != null || workitemPicker.SelectedProjects.Length > 0)
            {
                return workitemPicker.SelectedTeamProjectCollection;
            }
            return null;
        }
        private WorkItemCollection  WorkItemByQuery(TfsTeamProjectCollection projects, string query)  //query is likethis:SELECT [System.ID], [System.Title] FROM WorkItems WHERE [System.Title] CONTAINS 'Lei Yang'
        {
            WorkItemStore wis = new WorkItemStore(projects);
            return wis.Query (query );
        }
