    public sealed partial class MainPage : Page
    {
       private string eMailSubject;
       private string eMailHtmlText;
       ...
       private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
       {
          // Check if an email is there for sharing
          if (String.IsNullOrEmpty(this.eMailHtmlText) == false)
          {
             // Pass the current subject
             args.Request.Data.Properties.Title = this.eMailSubject;   
   
             // Pass the current email text
             args.Request.Data.SetHtmlFormat(
                HtmlFormatHelper.CreateHtmlFormat(this.eMailHtmlText));
 
             // Delete the current subject and text to avoid multiple sharing
             this.eMailSubject = null;
             this.eMailHtmlText = null;
          }
          else
          {
             // Pass a text that reports nothing currently exists for sharing
             args.Request.FailWithDisplayText("Currently there is no email for sharing");
          }
       }
       ...
       // "Send" an email
       this.eMailSubject = "Test";
       this.eMailHtmlText = "Hey,<br/><br/> " +
          "This is just a <b>test</b>.";
       DataTransferManager.ShowShareUI(); 
