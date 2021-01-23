    using Project1;
    namespace Project2
    {
        public class Project2Class
        {
            public void AccessProject1Class()
            {
                Project1Class project1Class = new Project1Class();
                project1Class.Foo();
            }
        }
    }
