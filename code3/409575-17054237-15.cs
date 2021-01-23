        public T[] ResolveAllWithParameters<T>(IDictionary<string,object> parameters )
        {
            var _parameters=new List<Parameter>();
            foreach (var parameter in parameters)
            {
                _parameters.Add( new NamedParameter(parameter.Key, parameter.Value));
            }
            return ContainerManager.ResolveAllWithParameters<T>(_parameters);
        }
