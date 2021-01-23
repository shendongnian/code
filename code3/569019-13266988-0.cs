    public class StringCombinatieRuimtesConverter : ITypeConverter<string, List<Ruimte>>
    {
        #region Implementation of ITypeConverter<in string,out List<Ruimte>>
        public List<Ruimte> Convert(ResolutionContext context)
        {
            if (context.SourceValue == null)
            {
                return new List<Ruimte>();
            }
            var list = context.SourceValue.ToString().Split(',').Select(r => new Ruimte { Id = int.Parse(r) }).ToList();
            List<Ruimte> destinationList = context.DestinationValue as List<Ruimte>;
            if (destinationList != null)
            {
                destinationList.AddRange(list);
            }
            return list;
        }
        #endregion
    }
