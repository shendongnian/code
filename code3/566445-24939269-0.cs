    private static TfsTeamProjectCollection _tfs;
    private static ProjectInfo _selectedTeamProject;
    
    // Connect to TFS Using Team Project Picker
    public static void ConnectToTfsUsingTeamProjectPicker()
    {
         // The  user is allowed to select only one project
         var tfsPp = new TeamProjectPicker(TeamProjectPickerMode.SingleProject, false);
         tfsPp.ShowDialog();
         // The TFS project collection
         _tfs = tfsPp.SelectedTeamProjectCollection;
         if (tfsPp.SelectedProjects.Any())
         {
              //  The selected Team Project
              _selectedTeamProject = tfsPp.SelectedProjects[0];
         }
     }
