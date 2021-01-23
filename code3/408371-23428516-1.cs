    public class MessageHandlerAdapterLister : ISpecifyMessageHandlerOrdering
    {
        public void SpecifyOrder(Order order)
        {
            //You would normally iterate through your message types (over DI registry or some other registry of messages):
            var adapterType1 = typeof(MessageHandlerAdapter<>).MakeGenericType(typeof(MyMessage1));
            var adapterType2 = typeof(MessageHandlerAdapter<>).MakeGenericType(typeof(MyMessage2));
    
            order.Specify(new[] { adapterType1, adapterType2 });
        }
    }
