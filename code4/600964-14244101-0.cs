    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NHibernate.Linq.Functions;
    using NHibernate.Linq;
    
    namespace ConsoleApplication14
    {
        public class MyLinqToHqlGeneratorsRegistry : DefaultLinqToHqlGeneratorsRegistry
        {
            public MyLinqToHqlGeneratorsRegistry()
                : base()
            {
            
                CalculatedPropertyGenerator<Common1, string>.Register(this, x => x.Display, Common1.CalculatedDisplayExpression);
            }
        }
    }
