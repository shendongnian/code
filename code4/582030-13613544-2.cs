    public class Main
    {
        public Main()
        {
            //Notice that either one of these implementations 
            //is accepted by BeginWork
            //Foo uses the abstract class
            IReady example = new Foo();
            UsesIReady workExample = new UsesIReady();
            workExample.BeginWork(example);
            //Bar uses the interface
            IReady sample = new Bar();
            UsesIReady workSample = new UsesIReady();
            workSample.BeginWork(sample);
        }
    }
