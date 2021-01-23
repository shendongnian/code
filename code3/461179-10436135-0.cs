    public interface IGameState{
      void Help();
      void Question();
      void Attack();
    }
    
    public interface ICommand{
      bool IsValidFor(PlayingState state);
      bool IsValidFor(BattleState state);
      void Execute(IGameState state);
    }
    
    public class PlayingState : IGameState {
       public void Help(){ // Do Nothing }
       public void Question() { WriteCommands(); }
    
       private void WriteCommands(){ }
    }
    
    public class Battle : IGameState{
       public void Help(){ // Do Nothing }
       public void Question() { WriteCommands(); }
       public void Attack() { Roll(7); }
    
       private void Roll(int numDice){ }
    }
    
    public class CommandBuilder{
      public ICommand Parse(string verb){
        switch(verb){
           case "help":
             return new HelpCommand();
           case "?":
             return new QuestionCommand();
           case "attack":
             return new AttackCommand();
           default:
             return new UnknownCommand();
        }
      }
    }
    
    public class QuestionCommand(){
      bool IsValidFor(PlayingState  state){
         return true;
      }
    
      bool IsValidFor(BattleState state){
         return false;
      }
    
      void Execute(IGameState state){
         state.Question();
      }
    }
    
    public static void Do(string aString){
      var command = CommandBuilder.Parse(aString);
      if(command.IsValidFor(Program.GameStates))
         command.Execute(Program.Gamestates);
    }
