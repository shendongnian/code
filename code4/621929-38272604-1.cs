    //The usings you need:
    using System;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.XPath;
    
    namespace ProcessXmlCons {
        class Inicial {
            static void Main( string[] args ) {
                new Inicial().Tests();
            }
    
            private void Tests() {
                Test01();
            }
    
            private void Test01() {
                var theDocumentContent = 
                  @"<?xml version=""1.0"" encoding=""utf-8""?>
                    <soap:Envelope xmlns:soap=""http://www.w3.org/2003/05/soap-envelope"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
                        <soap:Body>
                        <queryResponse xmlns=""http://SomeUrl.com/SomeSection"">
                            <response>
                                <theOperationId>105</theOperationId>
                                <theGeneraltheDetailsCode>0</theGeneraltheDetailsCode>
                                <theDetails>
                                    <aDetail>
                                        <aDetailId>111</aDetailId>
                                        <theValue>Some Value</theValue>
                                        <theDescription>Some description</theDescription>
                                    </aDetail>
                                    <aDetail>
                                        <aDetailId>222</aDetailId>
                                        <theValue>Another Value</theValue>
                                        <theDescription>Another description</theDescription>
                                    </aDetail>
                                    <aDetail>
                                        <aDetailId>333</aDetailId>
                                        <theValue>And another Value</theValue>
                                        <theDescription>And another description</theDescription>
                                    </aDetail>
                                </theDetails>
                            </response>
                        </queryResponse>
                        </soap:Body>
                    </soap:Envelope>
                    ";
    
                var theDocumentXDoc = XDocument.Parse( theDocumentContent );
                var theNamespaceIndicator = new XmlNamespaceManager( new NameTable() );
                theNamespaceIndicator.AddNamespace( "theSoapNS" , "http://www.w3.org/2003/05/soap-envelope" );
                theNamespaceIndicator.AddNamespace( "noSuffNS"  , "http://SomeUrl.com/SomeSection" );
    
                var theEnvelope = theDocumentXDoc.XPathSelectElement( "//theSoapNS:Envelope", theNamespaceIndicator );
                Console.WriteLine( $"The envelope: {theEnvelope?.ToString()} " );
    
                var theEnvelopeNotFound = theDocumentXDoc.XPathSelectElement( "//Envelope", theNamespaceIndicator );
                Console.WriteLine( "".PadRight( 120, '_' ) ); //Visual divider
                Console.WriteLine( $"The other envelope: \r\n {theEnvelopeNotFound?.ToString()} " );
    
                var theQueryResponse = theDocumentXDoc.XPathSelectElement( "//theSoapNS:Envelope/theSoapNS:Body/noSuffNS:queryResponse", theNamespaceIndicator );
                Console.WriteLine( "".PadRight( 120, '_' ) ); //Visual divider
                Console.WriteLine( $"The query response: \r\n {theQueryResponse?.ToString()} " );
    
                var theDetails = theDocumentXDoc.XPathSelectElement( "//theSoapNS:Envelope/theSoapNS:Body/noSuffNS:queryResponse/noSuffNS:response/noSuffNS:theDetails", theNamespaceIndicator );
                Console.WriteLine( "".PadRight( 120, '_' ) ); //Visual divider
                Console.WriteLine( $"The details: \r\n {theDetails?.ToString()} " );
                Console.WriteLine( "".PadRight( 120, '_' ) ); //Visual divider
    
                foreach ( var currentDetail in theDetails.Descendants().Where( elementToFilter => elementToFilter.Name.LocalName != "aDetail" ) ) {
                    Console.WriteLine( $"{currentDetail.Name.LocalName}: {currentDetail.Value}" );
                }
    
                //Not optimal. Just to show XPath select withing another selection:
                Console.WriteLine( "".PadRight( 120, '_' ) ); //Visual divider
                Console.WriteLine( "Values only:" );
                foreach ( var currentDetail in theDetails.Descendants() ) {
                    var onlyTheValueElement = currentDetail.XPathSelectElement( "noSuffNS:theValue", theNamespaceIndicator );
                    if ( onlyTheValueElement != null ) {
                        Console.WriteLine( $"--> {onlyTheValueElement.Value}" );
                    }
                }
            }
    
        } //class Inicial
    } //namespace ProcessXmlCons
