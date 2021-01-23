    <Order>
      <AmazonOrderID>000-1111111-2222222</AmazonOrderID>
      <MerchantOrderID>111-3333333-4444444</MerchantOrderID>
      <PurchaseDate>2012-03-02T13:28:53+00:00</PurchaseDate>
      <LastUpdatedDate>2012-03-02T13:29:05+00:00</LastUpdatedDate>
      <OrderStatus>Pending</OrderStatus>
      <SalesChannel>Amazon.com</SalesChannel>
      <URL>http://www.amazon.com</URL>
      <FulfillmentData>
        <FulfillmentChannel>Amazon</FulfillmentChannel>
        <ShipServiceLevel>Standard</ShipServiceLevel>
        <Address>
          <City>Beverly Hills</City>
          <State>CA</State>
          <PostalCode>90210-1234</PostalCode>
          <Country>US</Country>
        </Address>
      </FulfillmentData>
      <OrderItem>
        <ASIN>AmazonASIN </ASIN>
        <SKU> Internal-SKU</SKU>
        <ItemStatus>Pending</ItemStatus>
        <ProductName> This is the name of the product </ProductName>
        <Quantity>1</Quantity>
        <ItemPrice>
          <Component>
            <Type>Principal</Type>
            <Amount currency="USD">19.99</Amount>
          </Component>
        </ItemPrice>
      </OrderItem>
    </Order>
    
        List<string> getNodes(string path, string nodeName) {
    
        List<string> nodes = new List<string>(); 
    
        XDocument xmlDoc = XDocument.Load(path); //Create the XML document type
    
        foreach (var el in xmlDoc.Descendants(nodeName)) {
                //for debugging
                //nodes.Add(el.Name + " " + el.Value);
    
                //for production
                nodes.Add(el.Value);
        }
       return nodes;
    } //end getNodes
    
    List<string> skuNodes = xml.getNodes(@"AmazonSalesOrders.xml", "SKU");
