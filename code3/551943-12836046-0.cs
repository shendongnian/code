    <% Html.BeginForm("MyAction", "MyController", FormMethod.Post); %>
    <input type="submit" name="submitButton" value="Send" />
    <input type="submit" name="submitButton" value="Cancel" />
    <% Html.EndForm(); %>
    public class MyController : Controller {
        public ActionResult MyAction(string submitButton) {
            switch(submitButton) {
                case "Send":
                    // delegate sending to another controller action
                    
                case "Cancel":
                    // call another action to perform the cancellation
                    
                default:
                    // If they've submitted the form without a submitButton, 
                    // just return the view again.
                    return(View());
            }
        }
  
