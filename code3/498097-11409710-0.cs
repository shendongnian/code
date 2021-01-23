    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    class Program
    {
        private const string Xml =
            @"<Message>
        <MessageID>1</MessageID>
        <ProcessingReport>
            <DocumentTransactionID>123456789</DocumentTransactionID>
            <StatusCode>Complete</StatusCode>
            <ProcessingSummary>
                <MessagesProcessed>2</MessagesProcessed>
                <MessagesSuccessful>0</MessagesSuccessful>
                <MessagesWithError>2</MessagesWithError>
                <MessagesWithWarning>0</MessagesWithWarning>
            </ProcessingSummary>
            <Result>
                <MessageID>1</MessageID>
                <ResultCode>Error</ResultCode>
                <ResultMessageCode>90205</ResultMessageCode>
                <ResultDescription>Some Text Here</ResultDescription>
                <AdditionalInfo>
                    <SKU>12345</SKU>
                </AdditionalInfo>
            </Result>
            <Result>
                <MessageID>2</MessageID>
                <ResultCode>Error</ResultCode>
                <ResultMessageCode>90205</ResultMessageCode>
                <ResultDescription>Some Text Here</ResultDescription>
                <AdditionalInfo>
                    <SKU>67890</SKU>
                </AdditionalInfo>
            </Result>
        </ProcessingReport>
    </Message>
    ";
    
        static void Main(string[] args)
        {
            var doc = XDocument.Parse(Xml);
    
            foreach (var result in doc.Descendants("Result").Where(x => x.Element("ResultCode").Value == "Error"))
            {
                Console.WriteLine("MessageID: {0}; ResultMessageCode: {1}; ResultDescription: {2}", 
                    result.Element("MessageID").Value,
                    result.Element("ResultMessageCode").Value,
                    result.Element("ResultDescription").Value
                    );
            }
        }
    }
