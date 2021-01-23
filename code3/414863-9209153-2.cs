    public class StringThatReallyIsANumberGenerator : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            var targetProperty = request as PropertyInfo;
    
            if (targetProperty == null)
            {
                return new NoSpecimen(request);
            }
    
            if (targetProperty.Name != "StringThatReallyIsANumber")
            {
                return new NoSpecimen(request);
            }
    
            var value = context.CreateAnonymous<int>();
            return value.ToString();
        }
    }
