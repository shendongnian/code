    internal abstract class FormInfo
    {
        private readonly TmwFormFieldInfo[] _orderedFields;
        
        protected FormInfo(OrderedFieldReader fieldReader)
        {
            _orderedFields = fieldReader.GetOrderedFields(formType);
        }
        protected abstract class OrderedFieldReader
        {
            public abstract TmwFormFieldInfo[] GetOrderedFields(Type formType);
        }
    }
    internal sealed class HeaderFormInfo : FormInfo
    {
        public HeaderFormInfo()
            : base(new OrderedHeaderFieldReader())
        {
        }
        
        private sealed class OrderedHeaderFieldReader : OrderedFieldReader
        {
            public override TmwFormFieldInfo[] GetOrderedFields(Type formType)
            {
                // Return the header fields
            }
        }
    }
    internal class MessageFormInfo : FormInfo
    {
        public MessageFormInfo()
            : base(new OrderedMessageFieldReader())
        {
        }
        private sealed class OrderedMessageFieldReader : OrderedFieldReader
        {
            public override TmwFormFieldInfo[] GetOrderedFields(Type formType)
            {
                // Return the message fields
            }
        }
    }
