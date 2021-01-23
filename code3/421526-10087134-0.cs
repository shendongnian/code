        // Hide default implementation and call BaseShow instead
        public new void Show()
        {
            BaseShow();
        }
        protected virtual void BaseShow()
        {
            base.Show();
        }
        // ... abstract away any additional Window methods and properties required 
    }
