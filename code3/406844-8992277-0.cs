     [HttpPost]
        public ActionResult AddItem(FullOrder f)
        {
             // Next line is just showing that you should get the existing order
             // from your data layer
             FullOrder existingOrder = orderRepository.GetExistingOrder();
             // Now loop through f.OrderList and update the quantities
             foreach(OrderItem item in f.OrderList) {
                 // Find the existing item and update the quantity.
             }
             // Now you have the original information from the DB along with
             // updated quantities.
             // Save results or do whatever is next
             existingOrder.Save();
        }
