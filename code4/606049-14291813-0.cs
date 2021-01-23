            if (projObj is Project)
            {
                Project selectedProject = (Project)projObj;
                MessageBox.Show(selectedProject.FullName);
            }
            else if(projObj is ProjectItem)
            {
                ProjectItem selectedProject = (ProjectItem)projObj;
                MessageBox.Show(selectedProject.get_FileNames(1));
            }
