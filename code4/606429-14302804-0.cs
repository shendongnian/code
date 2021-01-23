Pids = item.Element("CurrentOrderDetails")
    .Elements("ProductsId")
    .Select(e => e.Value).ToArray()</code></pre>
If you want all your entries as a flat list, the way to go would be
var data = from item in doc.Descendants("Order")
           from product in item.Element("CurrentOrderDetails").Elements("ProductsId")
                     select new
                     {
                         OrderID = item.Element("OrderID").Value,
                         POnumber = item.Element("PurchaseOrderNumber").Value,
                         OrderDate = item.Element("OrderPlacedDate").Value,
                         PFirstName = item.Element("purchasingContact")
                             .Element("FirstName").Value,
                         Pid = product.Value
                      };</code></pre>
By the way: the XML model should have a surrounding element around the productsid and orderquantity explicitly modelling an order row. That would be more expressive and intuitive.
