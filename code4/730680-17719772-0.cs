    class Program
    {
        class Project
        {
            public string Name;
        }
        static void Main(string[] args)
        {
            List<Project> projectList = new List<Project>(){
                new Project(){Name="Project1"},
                new Project(){Name="Project2"}
            };
            dynamic projectsObject = new ExpandoObject();
            foreach (var project in projectList)
            {
                ((IDictionary<string, object>)projectsObject).Add(project.Name, project);
            }
            Console.WriteLine(projectsObject.Project1.Name);
        }
    }
