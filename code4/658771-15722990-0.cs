        public void Handle(NavigateEvent navigate)
        {
            InnerViewModel target;
            switch (navigate.TargetViewModel)
            {
                case typeof(SelectProjectViewModel):
                {
                    target = new SelectProjectViewModel(_eventAggregator);
                    break;
                }
                case typeof(OverviewViewModel):
                {
                    target = new OverviewViewModel(_eventAggregator);
                    break;
                }
                default:
                {
                    throw new InvalidOperationException("no target type found");
                }
            }
            this.CurrentInnerViewModel = target;
        }
