    public static class Extensions
    {
        public static IEnumerable<MyClass> isActive(this IEnumerable<MyClass> list)
        {
            return list.Where(a =>  
                   ((a.publishEnd > DateTime.Now) || (a.publishEnd == null))
                     && ((a.publishStart <= DateTime.Now) || (a.publishStart == null))
                     && a.active == true);
        }
    }
