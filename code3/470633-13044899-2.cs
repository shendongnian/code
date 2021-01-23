    public static void EnsureEventReceiver(this SPList list,IEnumerable<SPEventReceiverType> receiverTypes, Type eventHander, SPEventReceiverSynchronization synchronization, int sequenceNumber)
    {
       foreach (SPEventReceiverType spEventReceiverType in receiverTypes)
       {
          string name = list.Title + spEventReceiverType.ToString();
          
          if (list.EventReceivers.Cast<SPEventReceiverDefinition>().All(i => i.Name != name))
          {
              SPEventReceiverDefinition eventReceiver = list.EventReceivers.Add();
              eventReceiver.Name = name;
              eventReceiver.Type = spEventReceiverType;
              eventReceiver.Assembly = eventHander.Assembly.FullName;
              eventReceiver.Class = eventHander.FullName;
              eventReceiver.SequenceNumber = sequenceNumber;
              eventReceiver.Synchronization = synchronization;
              eventReceiver.Update();
          }
       }    
    }
