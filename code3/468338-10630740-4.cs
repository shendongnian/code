     class Program
    {
        static void Main(string[] args)
        {
            var myEngineer = ProfessionFactory.CreateProffession<Engineer>();
            var myDoctor = ProfessionFactory.CreateProffession<Doctor>();
            myEngineer.EnginerringStuff();
            myDoctor.HealingPeople();
            var myEngineer2 = (Engineer)ProfessionFactory.CreateProffession("Engineer");
            //using the other method I still have to cast in order to access Engineer methods.
            //therefore knowing what type to create is essential unless we don't care about engineer specific methods,
            //in that case we can do:
            var myEngineer3 = ProfessionFactory.CreateProffession("Engineer");
            //which is useless unless we start involving reflections which will have its own price..
        }
        public interface IProfessionFactory
        {
            IProfession CreateObj(); 
        }
        public interface IProfession : IProfessionFactory
        {
            string ProfessionName { get; }
        }
        public abstract class ProfessionFactory : IProfessionFactory
        {
            public abstract IProfession CreateObj();
            public static T CreateProffession<T>() where T:IProfessionFactory, new()
            {
                return (T)new T().CreateObj();
            }
            public static IProfession CreateProffession(object dataObj)
            {
                if (dataObj == "Engineer")
                    return CreateProffession<Engineer>();
                if (dataObj == "Doctor")
                    return CreateProffession<Doctor>();
                throw new Exception("Not Implemented!");
            }
        }
        public class Engineer : IProfession
        {
            public string ProfessionName
            {
                get { return "Engineer"; }
            }
            public IProfession CreateObj()
            {
                return new Engineer();
            }
            public void EnginerringStuff()
            {}
        }
        public class Doctor : IProfession
        {
            public string ProfessionName
            {
                get { return "Doctor"; }
            }
            public IProfession CreateObj()
            {
                return new Doctor();
            }
            public void HealingPeople()
            {}
        }
    }
