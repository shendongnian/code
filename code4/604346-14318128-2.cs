        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);
            if (!e.Handled)
            {
                if ((this.moduleTrackingState != null) && (this.moduleTrackingState.ExpectedInitializationMode == InitializationMode.OnDemand) && (this.moduleTrackingState.ModuleInitializationStatus == ModuleInitializationStatus.NotStarted))
                {
                    this.RaiseRequestModuleLoad();
                    e.Handled = true;
                }
            }
        }
