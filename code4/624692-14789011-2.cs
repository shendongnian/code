    using System;
    using System.IO;
    using System.Xml.Linq;
    using System.Xml.XPath;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Fix original XML, which has multiple root nodes!
                // We fix it just by enclosing it in a root level element called "Root":
                string xml = "<Root>" + originalXml() + "</Root>";  
                // Read the XML as an XML element.
                var xElement = XElement.Load(new StringReader(xml));
                // Easily access 'Locality' or any other node by name:
                string locality = xElement.XPathSelectElement("Address/Locality").Value.Trim();
                Console.WriteLine("Locality = " + locality);
            }
            // Note: This XML isn't well-formed, because it has multiple root nodes.
            private static string originalXml()
            {
                return
    @"<Name>
    High Street, Lincoln, LN5 7
    </Name>
    <Point>
    <Latitude>
    53.226592540740967
    </Latitude>
    <Longitude>
    -0.54169893264770508
    </Longitude>
    </Point>
    <BoundingBox>
    <SouthLatitude>
    53.22272982317029
    </SouthLatitude>
    <WestLongitude>
    -0.55030130347707928
    </WestLongitude>
    <NorthLatitude>
    53.230455258311643
    </NorthLatitude>
    <EastLongitude>
    -0.53309656181833087
    </EastLongitude>
    </BoundingBox>
    <EntityType>
    Address
    </EntityType>
    <Address>
    <AddressLine>
    High Street
    </AddressLine>
    <AdminDistrict>
    England
    </AdminDistrict>
    <AdminDistrict2>
    Lincs
    </AdminDistrict2>
    <CountryRegion>
    United Kingdom
    </CountryRegion>
    <FormattedAddress>
    High Street, Lincoln, LN5 7
    </FormattedAddress>
    <Locality>
    Lincoln
    </Locality>
    <PostalCode>
    LN5 7
    </PostalCode>
    </Address>";
            }
        }
    }
