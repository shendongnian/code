        public class WindsorHandlerOverride : IHandlerSelector
    {
        private Dictionary<Type, object> definedTypeBehaviours;
        public bool HasOpinionAbout(string key, Type service)
        {
            return definedTypeBehaviours.IsNotNullAndAny(t => t.Key == service);
        }
        public IHandler SelectHandler(string key, Type service, IHandler[] handlers)
        {
            var theValue = definedTypeBehaviours[service];
            return new WindsorSimpleHandler {TheValue = theValue};
        }
        public void CleanUp()
        {
            definedTypeBehaviours = null;
        }
        public void OverrideBehaviour(Type type, object value)
        {
            if (definedTypeBehaviours == null)
            {
                definedTypeBehaviours = new Dictionary<Type, object>();
            }
            definedTypeBehaviours.Add(type, value);
        }
    }
