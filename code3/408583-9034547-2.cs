        bool isFirstTimeActivated = true;
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
               
            if (this.isFirstTimeActivated)
            {
                 // your code here
                 this.isFirstTimeActivated = false;
            }
        }
