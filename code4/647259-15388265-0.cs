    public class CreateSomeThingVM
    {
      public string Title { set;get;}  
      public List<Stage> Stages { set;get;}
     
      public CreateSomeThingVM()
      {
        Stages=new List<Stage>();
      }
    }
    public class Stage
    {
      public int ID { set;get;}
      public string StageName { set;get;}
      public List<Action> Actions { set;get;}
      public Stage()
      {
        Actions =new List<Action>();
      }
    }
    public class Action
    {
      public int ID { set;get;}
      public string ActionName { set;get;}
    }
