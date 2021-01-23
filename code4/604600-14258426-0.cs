    public class Field: AggregateRoot
    {
        public UpdateField()
        {
             // do some business
             // and trigger FieldUpdatedEvent with necessary parameters
             ....
             // you can update some quadrants
             // and trigger QuadrantsUpdatedEvent with necessary parameters
        }
    }
    
    public class FieldEventHandlers: EventHandler 
    {
        void Handle (FieldUpdatedEvent e)
        {
             repository.Update(e.Field);
        }
    }
    
    public class QuadrantEventHandlers: EventHandler 
    {
        void Handle (QuadrantsUpdatedEvent e)
        {
             repository.Update(e.Quadrant);
        }
    }
