        public PCMGenViewModel()
        {
            PGenWidgets = new ObservableCollection<PCMGenWidgetViewModel>();
            PGenWidgets.Add(new PCMGenWidgetViewModel { Description = "PCM Generator 1", ID=0 });
            PGenWidgets.Add(new PCMGenWidgetViewModel { Description = "PCM Generator 2", ID=1 });            
        }
