    public class SomeTextBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            var pi = request as PropertyInfo;
            if (pi != null && 
                pi.Name == "SomeText" &&
                pi.PropertyType == typeof(string))
                return context.Resolve(typeof(string))
                    .ToString().Substring(0, 10);
            
            return new NoSpecimen(request);
        }
    }
