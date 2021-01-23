        public class MyProjectContext : DbContext
        {
            public MyProjectContext()
                : base("name=ConnectionStringNameHere")
            {
            }
        }
