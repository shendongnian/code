    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication4
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xmlstr = @"
                        <root>
                        <ItemAttributes>
                        <Author>Ellen Galinsky</Author>
                        <Binding>Paperback</Binding>
                        <Brand>Harper Paperbacks</Brand>
                        <EAN>9780061732324</EAN>
                        <EANList>
                        <EANListElement>9780061732324</EANListElement>
                        </EANList><Edition>1</Edition>
                        <Feature>ISBN13: 9780061732324</Feature>
                        <Feature>Condition: New</Feature>
                        <Feature>Notes: BRAND NEW FROM PUBLISHER! 100% Satisfaction Guarantee. Tracking provided on most orders. Buy with Confidence! Millions of books sold!</Feature>
                        <ISBN>006173232X</ISBN>
                        <IsEligibleForTradeIn>1</IsEligibleForTradeIn>
                        <ItemDimensions>
                        <Height Units=""hundredths-inches"">112</Height>
                        <Length Units=""hundredths-inches"">904</Length>
                        <Weight Units=""hundredths-pounds"">98</Weight>
                        <Width Units=""hundredths-inches"">602</Width>
                        </ItemDimensions>
                        <Label>William Morrow Paperbacks</Label>
                        <ListPrice>
                        <Amount>1699</Amount>
                        <CurrencyCode>USD</CurrencyCode>
                        <FormattedPrice>$16.99</FormattedPrice>
                        </ListPrice>
                        <Manufacturer>William Morrow Paperbacks</Manufacturer>
                        <MPN>006173232X</MPN>
                        <NumberOfItems>1</NumberOfItems>
                        <NumberOfPages>400</NumberOfPages>
                        <PackageDimensions>
                        <Height Units=""hundredths-inches"">120</Height>
                        <Length Units=""hundredths-inches"">880</Length>
                        <Weight Units=""hundredths-pounds"">95</Weight>
                        <Width Units=""hundredths-inches"">590</Width>
                        </PackageDimensions>
                        <PartNumber>006173232X</PartNumber>
                        <ProductGroup>Book</ProductGroup>
                        <ProductTypeName>ABIS_BOOK</ProductTypeName>
                        <PublicationDate>2010-04-20</PublicationDate>
                        <Publisher>William Morrow Paperbacks</Publisher>
                        <ReleaseDate>2010-04-20</ReleaseDate>
                        <SKU>mon0000013657</SKU>
                        <Studio>William Morrow Paperbacks</Studio>
                        <Title>Mind in the Making: The Seven Essential Life Skills Every Child Needs</Title>
                        </ItemAttributes>
                        </root>
                        ";
                XDocument xdoc = XDocument.Load(new StringReader(xmlstr));
                var foundNode = xdoc
                    .Descendants("ItemAttributes")
                    .Where(node => node.Element("ProductGroup").Value == "Book")
                    .First();
                Console.WriteLine(foundNode.Element("ListPrice").Element("FormattedPrice").Value);
                Console.ReadLine();
            }
        }
    }
