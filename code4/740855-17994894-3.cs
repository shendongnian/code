            public abstract class ApplicationPageBase : Page
            {
               private Popup settingsPopup;
               private bool _IsPopOpen;
               public bool IspopOpen { get;set; }
               public ApplicationPageBase()
                {
                   InitiatePopUp();
                }
               void InitiatePopUp()
                 {
                    settingsPopup = new Popup();
                     //do some code for popup
                 }
            }
