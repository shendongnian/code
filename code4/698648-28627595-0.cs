    internal sealed class CustomConstructorBuilder<T> : ISpecimenBuilder
    {
        private readonly Dictionary<string, object> _ctorParameters = new Dictionary<string, object>();
 
        public object Create(object request, ISpecimenContext context)
        {
            var type = typeof (T);
            var sr = request as SeededRequest;
            if (sr == null || !sr.Request.Equals(type))
            {
                return new NoSpecimen(request);
            }
 
            var ctor = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault();
            if (ctor == null)
            {
                return new NoSpecimen(request);
            }
 
            var values = new List<object>();
            foreach (var parameter in ctor.GetParameters())
            {
                if (_ctorParameters.ContainsKey(parameter.Name))
                {
                    values.Add(_ctorParameters[parameter.Name]);
                }
                else
                {
                    values.Add(context.Resolve(parameter.ParameterType));
                }
            }
            return ctor.Invoke(BindingFlags.CreateInstance, null, values.ToArray(), CultureInfo.InvariantCulture);
        }
 
        public void Addparameter(string paramName, object val)
        {
            _ctorParameters.Add(paramName, val);
        }
     }
