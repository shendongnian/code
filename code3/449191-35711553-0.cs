     public class StringBuilder : ISpecimenBuilder
        {
            private readonly Random rnd = new Random();
    
            public object Create(object request, ISpecimenContext context)
            {
                var type = request as Type;
    
                if (type == null || type != typeof(string))
                {
                    return new NoSpecimen();
                }
    
                return rnd.Next(0,10000).ToString();
            }
        }
