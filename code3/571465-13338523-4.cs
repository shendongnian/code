    var arrayOfX = new X[] {new X {A = "String A", B = new Y[] { new Y { C = "String C", D = new Z[0]}}}};
    Mapper.CreateMap<X, Destination>().ConvertUsing<XDestinationConverter>();  
    var result = Mapper.Map<IEnumerable<X>, IEnumerable<Destination>>(arrayOfX); 
    
    public class XDestinationConverter : ITypeConverter<X, Destination>
    {
        public Destination Convert(ResolutionContext context)
        {
            var destination = new Destination();
            var x = (X) context.SourceValue;
            if (x == null)
                return destination;
            destination.A = x.A;
            destination.C = x.B != null && x.B.Count() > 0 ? x.B.Select(y => y.C).First() : null;
            destination.E = x.B != null && x.B.Count() > 0 ? x.B.Select(y => y.C).First() != null && x.B.Select(y => y.C).First().Count() > 0 ? x.B.Select(y => y.D).First() != null && x.B.Select(y => y.D).Count() > 0 ? x.B.Select(y => y.D).First().Select(z => z.E).First() : null : null : null;
            destination.F = x.B != null && x.B.Count() > 0 ? x.B.Select(y => y.C).First() != null && x.B.Select(y => y.C).First().Count() > 0 ? x.B.Select(y => y.D).First() != null && x.B.Select(y => y.D).Count() > 0 ? x.B.Select(y => y.D).First().Select(z => z.F).First() : null : null : null;
            return destination;
        }
    }
