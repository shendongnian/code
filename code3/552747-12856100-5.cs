    public class ExampleHandler : BaseHandler,
                                  IHandler<ExampleMessage>,
                                  IHandler<OtherExampleMessage>
    {
        public void Handle(ExampleMessage m)
        {
            "ExampleMessage".Dump();
        }
    
        public void Handle(OtherExampleMessage m)
        {
            "OtherExampleMessage".Dump();
        }
    }
