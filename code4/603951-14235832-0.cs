    public class Command {
    
       public static Command Create(string[] textLines) {
         var args = textLines.Select(l => parseLine(l));
         var argTypes = args.Select(a => a.GetType().ToArray();
         return (Command)typeof(Command).GetMethod("Create",argTypes).Invoke(null,args);
       }
    
       public static Command Create(int commandType,
                                    bool IsSponk,
                                    int count, 
                                    string description){
           return new CommandType1(commandType,
                                   IsSponk,
                                   count,
                                   description);
       }
       private class CommandType1 : Command {
           public CommandType1(int commandType, bool IsSponk, int count, string description){
                ....
           }
       }
    }
