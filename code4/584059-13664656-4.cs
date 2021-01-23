    List<Pickup> listOfPickups = visits.listPickups();
    List<Delivery> listOfdeliveries = visits.listDeliveries();
    ViewListBox.Items.AddRange(listOfPickups.ToArray());
    ViewListBox.Items.AddRange(listOfdeliveries.ToArray());
    //...
    
    if (ViewListBox.SelectedIndex < listOfPickups.Count)
    {
       // this is a Pickup
       visits.removePickup(ViewListBox.SelectedIndex);
    }
    else
    {
       // this is a delivery
       int deliveryIndex = ViewListBox.SelectedIndex - listOfPickups.Count;
       visits.removeDelivery(deliveryIndex);
    }
