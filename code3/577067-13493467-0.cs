            foreach (var projects in projectDataSet.Project)
            {
                var project = projectDataSet as SvcProject.ProjectDataSet.ProjectRow;
                Console.WriteLine(project.PROJ_NAME);
            }
