    public class TextPresenter
    {
        ...
    
        void DetailView_EditClicked(object sender, EventArgs e)
        {
            //Calling Model's Functionality
            contactsModelController.StoreText(viewObj.InputtedText);
    
            // Save to session and redirect
            viewObj.SessionTextEntry = GetTextForSession(viewObj.InputtedText);
            viewObj.RedirectToTestPage();
        }
    
        // data processing logic
        private string GetTextForSession(string inputtedText)
        {
            if (inputtedText.Length > 0 && inputtedText.Length <= 100)
                return "1-100 " + inputtedText;
            
            if (inputtedText.Length > 100 && inputtedText.Length <= 1000)
                return "101-1000" + inputtedText;
            
            return "1001 - 2000" + inputtedText;
        }
    
        ...
    }
