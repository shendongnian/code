    using (LINQtoEntitiesEntities MyEntities = new LINQtoEntitiesEntities())
    {
       ObjectQuery<Employee> Employee = MyEntities.Employee;
       ObjectQuery<Tasks> Tasks = MyEntities.Tasks;
       Global.Task = (from e in Employee where e.LastName == lastName && e.FirstName == firstName join t in Tasks on e.ID equals t.ID select t.TaskName).FirstOrDefault();
    }
