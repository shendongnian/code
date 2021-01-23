    public class ClassACustomization: ICustomization
    {
        public double ParameterA { get; set;}
        public double ParameterB { get; set;}
        public void Customize(IFixture fixture)
        {
             //Note: these can be initialized how you like, shown here simply for convenience.
             ParameterA = fixture.Create<double>();
             ParameterB = fixture.Create<double>();
             fixture.Customize<ClassA>(c => c
               .FromFactory(() => 
               new ClassA(ParameterA , ParameterB )));
        }
    }
