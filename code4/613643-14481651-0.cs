    public EventViewModel
    {
      public int ID { set;get;}
      public string EventName { set;get;}
      public List<Participant> Participants {set;get;}
      public EventViewModel()
      {
        Participants=new List<Participant>();
      }
    }
    public class Participant
    {
      public string FirstName { set;get;}
      public string LastName { set;get;}
    }
