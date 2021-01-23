    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    
    class Program
    {
        class Project
        {
            public string Name;
        }
        static void Main(string[] args)
        {
            List<Project> projectList = new List<Project>(){
                new Project(){ Name="0" },
                new Project(){ Name="Project1" },
                new Project(){ Name="Project 1" },
                new Project(){ Name="Project 2" }
            };
            dynamic projectsObject = new ExpandoObject();
            foreach (var project in projectList)
            {
                ((IDictionary<string, object>)projectsObject)
                    .Add(project.Name, project);
            }
            // Now you can access the Project1 variable
            Console.WriteLine(projectsObject.Project1.Name);
            // But you need to follow the syntax conventions when 
            // assigning project names, as they will not be available 
            // as properties. Use the following syntax instead:
            Console.WriteLine(
                ((IDictionary<string, dynamic>)projectsObject)["0"].Name);
            Console.WriteLine(
                ((IDictionary<string, dynamic>)projectsObject)["Project 1"].Name);
        }
    }
