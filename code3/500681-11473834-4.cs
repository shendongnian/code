      [HttpPost]
      [Authorize]
      public ActionResult Add(Item item)
      {
          MyHubMethodCopy(item);
          var hubContext = GlobalHost.ConnectionManager.GetHubContext<SignalR.NotificationsHub>();
        hubContext.Clients.addNotification("Items were added");
    
      }
    
      private void MyHubMethodCopy(Item item)
      {
          itemService.AddItem(item);
      }
