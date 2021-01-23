    try
        {
            Projects = await projectTable
                .Where(Project => Project.ID != 0)
                .ToCollectionAsync();
            //Bind Projects to ListBox
            ListBox.ItemsSource = Projects;
        }
