        public abstract class BaseClass
        {
            public static BaseClass CreateInstance(DataTable dataTable)
            {
                return new Child1(dataTable);
            }
    
            private Child1 : BaseClass
            {
                public Child1(DataTable dataTable)
                {
                }
            }
        }
