            // This part in the constructor of the page
            InputPane inputPane = InputPane.GetForCurrentView();
            inputPane.Showing += InputPane_Showing;
            inputPane.Hiding += InputPane_Hiding;
        private void InputPane_Hiding(InputPane sender, InputPaneVisibilityEventArgs args) {
          
             // Do what you want.
        }
        private void InputPane_Showing(InputPane sender, InputPaneVisibilityEventArgs args) {
                Debug.WriteLine("Keyboard Height: "sender.OccludedRect.Height);
 
            
        }
