    class Program
    {
        static void Main(string[] args)
        {
            var myEngineer = ProfessionFactory.CreateProffession<Engineer>();
            var myDoctor = ProfessionFactory.CreateProffession<Doctor>();
            myEngineer.EnginerringStuff();
            myDoctor.HealingPeople();
        }
        public interface IProfessionFactory
        {
            IProfession CreateObj(); 
        }
        public interface IProfession
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
        }
        public class Engineer : ProfessionFactory, IProfession
        {
            public string ProfessionName
            {
                get { return "Engineer"; }
            }
            public override IProfession CreateObj()
            {
                return new Engineer();
            }
            public void EnginerringStuff()
            {}
        }
        public class Doctor : ProfessionFactory, IProfession
        {
            public string ProfessionName
            {
                get { return "Doctor"; }
            }
            public override IProfession CreateObj()
            {
                return new Doctor();
            }
            public void HealingPeople()
            {}
        }
    }
