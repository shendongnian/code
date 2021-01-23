    public enum ConfirmationResult
    {
      Yes,
      No, 
      Cancel
      ..etc
    }
    public enum ConfirmationType
    {
      YesNo,
      OkCancel
      ..etc    
    }
    public interface IConfirmation
    {
      ConfirmationResult ShowConfirmation(string message, ConfirmationType confirmationType)
    }
    public class MessageBoxConfirmation : IConfirmation
    {
      ConfirmationResult ShowConfirmation(string message, ConfirmationType confirmationType)
      {
        // convert ConfirmationType into MessageBox type here
        // MessageBox.Show(...)
        // convert result to ConfirmationResult type
      }
    }
