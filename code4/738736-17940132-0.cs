    string json = new JavaScriptSerializer().Serialize(new {
      ReferenceNumber = "Testing OAKLAND",
      CustomerNotes = "Testing",
      DeliveryDate = DateTime.Now,
      OrderLineItems = new List<object>() {
        new { ItemEntityId = 14771, Quantity = 2 }
      }
    });
