    /// <summary>
    /// Customisation to ignore the virtual members in the class - helps ignoring the navigational 
    /// properties and makes it quicker to generate objects when you don't care about these
    /// </summary>
    public class IgnoreVirtualMembers : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            var pi = request as PropertyInfo;
            if (pi == null)
            {
                return new NoSpecimen(request);
            }
            if (pi.GetGetMethod().IsVirtual)
            {
                return null;
            }
            return new NoSpecimen(request);
        }
    }
