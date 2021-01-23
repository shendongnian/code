    public class StringThatReallyIsANumberSequenceGenerator : ISpecimenBuilder
    {
        private int baseValue;
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
            var value = GetNextNumberInSequence();
            return value.ToString();
        }
        private int GetNextNumberInSequence()
        {
            return Interlocked.Increment(ref baseValue);
        }
    }
