    public interface IAgencyRentalParser
    {
        XmlDocument ToXml(Rental rental);
        Rental FromXml(XmlDocument xml);
    }
    public class Agency1RentalParser : IAgencyRentalParser { ... }
    public class Agency2RentalParser : IAgencyRentalParser { ... }
    public class Agency3RentalParser : IAgencyRentalParser { ... }
