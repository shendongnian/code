    public class ExampleHandler : BaseHandler,
                                  IHandler<ExampleMessage>,
                                  IHandler<OtherExampleMessage>
    {
        public void Handle(ExampleMessage message)
        {
            // handle ExampleMessage here
        }
    
        public void Handle(OtherExampleMessage message)
        {
            // handle OtherExampleMessage here
        }
    }
