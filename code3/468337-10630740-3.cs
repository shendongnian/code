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
