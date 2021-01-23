    		private static SolutionFolder GetSolutionFolder(Solution2 solution) {
			var project = GetSolutionFolderProject(solution);
			return (SolutionFolder) project.Object;
		}
		private static Project GetSolutionFolderProject(Solution2 solution) {
			var project =
				solution.Projects.Cast<Project>().FirstOrDefault(p => p.Name == "Solution Items");
			if (project == null) project = solution.AddSolutionFolder("Solution Items");
			return project;
		}
