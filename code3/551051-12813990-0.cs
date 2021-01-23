        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        { 
         while (NavigationService.BackStack.Count() >= 1)
                    NavigationService.RemoveBackEntry();
         }
