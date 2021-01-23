    class Program
    {
        static void Main(string[] args)
        {
            IList<XDocument> xmls = new List<XDocument>()
                                        {
                                            XDocument.Load("XMLFile1.xml"),
                                            XDocument.Load("XMLFile2.xml"),
                                            XDocument.Load("XMLFile3.xml")
                                        };
            Agency agency = new Agency();
            foreach (var xml in xmls)
            {
                var rental = new Rental();
                #region Pickup Date
                if (xml.Root.Attribute("pickup") != null)
                    rental.Pickup = DateTime.Parse(xml.Root.Attribute("pickup").Value);
                else if (xml.Root.Element("Pickup") != null)
                {
                    var pickupElement = xml.Root.Element("Pickup");
                    rental.Pickup = DateTime.Parse(pickupElement.Attribute("date") != null ? pickupElement.Attribute("date").Value : pickupElement.Value);
                }
                // else there's no pickup date defined
                #endregion
                agency.rentals.Add(rental);
            }
        }
    }
    public class Agency
    {
        public IList<Rental> rentals = new List<Rental>();
    }
    public class Rental
    {
        public DateTime Pickup;
    }
