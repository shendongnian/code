        public void Handle(NavigateEvent navigate)
        {
            InnerViewModel target;
            // EDIT: Remove the case (only works with integral types so you can't use typeof etc)
            // but you could do this with standard conditional logic
            this.CurrentInnerViewModel = target;
        }
