    class Shipment {
       // other fields...
       public Address Sender;
       public Address Recipient;
    }
    
    class Address {
        public string AddressText;
        public string CityName;
        public string CityId;
    }
    // in the service method
    var shipmentDtos = _context.Shipments.Where(s => request.ShipmentIdList.Contains(s.Id))
                    .Select(new SelectLambdaBuilder<Shipment>().CreateNewStatement(request.Fields)) // request.Fields = "Sender.CityName,Sender.CityId"
                    .ToList();
