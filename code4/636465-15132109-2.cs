    public class NHibernateActivator : INHibernateActivator, IPostLoadEventListener
    {
        public bool CanInstantiate(Type type)
        {
            return !type.IsAbstract && !type.IsInterface &&
                   !type.IsGenericTypeDefinition && !type.IsSealed;
        }
        public object Instantiate(Type type)
        {
            var instance = FormatterServices.GetUninitializedObject(type);
            instance.DisableInvariantEvaluation();
            return instance;
        }
        public void OnPostLoad(PostLoadEvent @event)
        {
            if (@event != null && @event.Entity != null)
                @event.Entity.EnableInvariantEvaluation(true);
        }
    }
