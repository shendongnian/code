    public interface IUserInput{
        string GetInput();
    }
    public static int Get_Commands(IUserInput input){
        do{
           string noOfCommands = input.GetInput();
           // Rest of code here
        }
     }
    public class Something : IUserInput{
         public string GetInput(){
               return Console.ReadLine().Trim();
         }
     }
     // Unit Test
     private class FakeUserInput : IUserInput{
          public string GetInput(){
               return "ABC_123";
          }
     }
     public void TestThisCode(){
        GetCommands(new FakeUserInput());
     }
