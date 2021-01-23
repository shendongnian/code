        public class SpecificClass : BaseClass
        {
        }
        public class BaseClass
        {
        }
        public class TemplatedClass<T>
        {
        }
        static void Main(string[] args)
        {
            var templateInstance = new TemplatedClass<SpecificClass>();
            var @true = typeof (BaseClass).IsAssignableFrom(templateInstance.GetType().GetGenericArguments()[0]);
            var templateInstance2 = new TemplatedClass<int>();
            var @false = typeof (BaseClass).IsAssignableFrom(templateInstance2.GetType().GetGenericArguments()[0]);
        }
