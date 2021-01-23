    public interface IActor {
       Stats Stats {get;}
       Vector2 Position {get;}
       bool IsFighting {get;}
       bool IsActive {get;}  // Or whatever you need
    }
    public class ActorManager {
         public static readonly Instance = new ActorManager();
         ActorManager();
         List<IActor> _actors = new List<IActor>();
         public IEnumerable<IActor> Actors {get{ return _actors;}}
         public void Addactor(IActor actor) { ... }
         
         public IEnumerable<IActor> GetActorsNear(IActor actor, float Radius)
         {
             return _actors.Where( 
                   secondary => actor != secondary 
                   && Vector2.Distance(actor.Position, secondary.Position)<Radius);
         }
         // or whatever you want to do with actors
    }
    public abstract class Actor : IActor
    {
       public Stats Stats {get; protected set;}
       public Vector2 Position {get;protected set;}
       public bool IsFighting {get;protected set;}
       public bool IsActive {get;protected set;} 
    
           public Actor() {
               ActorManager.Instance.Add(this);
           }
       public abstract void Controller();
    }
    public class Player : Actor { }  // Implements an input controller
    public class Npc : Actor { } // Implements a cpu IA controller
