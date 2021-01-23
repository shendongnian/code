        bool isFirstTimeActivated = true;
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
               
            if (isFirstTimeActivated)
            {
                 // your code here
                 isFirstTimeActivated = false;
            }
        }
