    public class Manager : ATypeResolver, IManager
    {
        private bool tryRetrieveFromReusable;
        public Manager(RuntimeConfiguration runtimeConfiguration, IList<RepositoryContainer> repositories)
        {
            this.tryRetrieveFromReusable = runtimeConfiguration.WhatEver;
        }
        public override TypeResolverResult<T> Resolve<T>()
        {
            var typeResolver = tryRetrieveFromReusable ? (TypeResolver<T>)TryRetrieveFromReusable : BuildNew;
            return typeResolver(new TypeResolverConfiguration<T>());
        }
    }
