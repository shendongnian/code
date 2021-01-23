      private void button1_Click(object sender, RoutedEventArgs e)
      {
         const long aNumber = 999999;
         var eventWhen = DateTime.Now;
         const string eventWhere = "Generic Kitchen";
         const string eventType = "Breakfast";
         const string aStatus = "Broken Toaster";
         var genericEventMessage = new GenericEventMessage
                                                      {
                                                         Number = aNumber,
                                                         EventWhen = eventWhen,
                                                         EventWhere = eventWhere,
                                                         EventType = eventType,
                                                         Status = aStatus
                                                      };
         App.Bus.Send(new TrackEventMesage(genericEventMessage));
      }
