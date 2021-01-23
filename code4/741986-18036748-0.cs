    using System;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Dispatcher;
    public class ObjectResolverInstanceProvider : IInstanceProvider
    {
        private readonly Type _serviceType;
        public ObjectResolverInstanceProvider(Type serviceType)
        {
            _serviceType = serviceType;
        }
        public object GetInstance(InstanceContext instanceContext)
        {
            return ObjectResolver.Resolve(_serviceType);
        }
        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return ObjectResolver.Resolve(_serviceType);
        }
        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            ObjectResolver.Release(instance);
        }
    }
