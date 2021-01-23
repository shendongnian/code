    // what you have now:
    namespace DAL.SQLServerDal
    {
        public class A {}
        public class B {}
    }
    // in other assembly
    using DAL.SQLServerDal ; // ok
    new A () ; // ok
    // with internal classes:
    namespace DAL.SQLServerDal
    {
        internal class A {}
        internal class B {}
    }
    // in other assembly
    using DAL.SQLServerDal ; // ok
    new A () ;               // error: A is inaccessible due to protection level
    // what I propose:
    namespace DAL
    {
        internal static class SQLServerDal
        {
            public class A {}
            public class B {}
        }
    }
    // in other assembly
    using DAL.SQLServerDal ; // error: namespace DAL.SQLServerDal does not exist
