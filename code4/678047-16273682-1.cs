    private SmartCollection<Event> eventCollection = new SmartCollection<Event>();
    private void dispatcherTimer_Tick(object sender, EventArgs e) {
      List<Event> newEvents = new List<Event>(500);
      for(var i = 0; i < 500; i++){
        newEvents.Add(new Event {
          Name = string.Format("Name_{0}", eventCollection.Count + i),
          Date = DateTime.Now.ToString("MM.dd.yy HH:mm"),
          Seconds = Convert.ToInt32(DateTime.Now.ToString("ss")),
          Desc = "Description"
        });
      }
      eventCollection.AddRange(newEvents);
    }
