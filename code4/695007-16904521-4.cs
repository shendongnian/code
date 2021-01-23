    class Execute
    {
        public object GetResult(object source)
        {
            var provider = new Provider();
            return provider.GetType()
                           .GetMethods()
                           .Where(x => x.Name == "GetResult" && x.ReturnType == source.GetType())
                           .First()
                           .Invoke(provider, new object[] { source });
        }
    }
