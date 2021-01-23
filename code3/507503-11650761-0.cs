        [HttpPost]
        public ActionResult Edit(Project project)
        {
            if (ModelState.IsValid)
            {
                if (project.Id == 0)
                {
                    ProjectRepository.Add(project);
                }
                else
                {
                    Project dbProject = ProjectRepository.GetById(project.Id); //or whatever your method to retrieve entities by Id is named
                    UpdateModel(dbProject, "project"); //http://msdn.microsoft.com/en-us/library/dd470933.aspx
                    ProjectRepository.Update(project);
                }
            }
        }
