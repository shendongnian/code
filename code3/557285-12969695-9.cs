        public PCMGenViewModel()
        {
            PGenWidgets = new ObservableCollection<PCMGenWidgetViewModel>();
            PGenWidgets.Add(new PCMGenWidgetViewModel { Description = "PCM Generator 1", ID=1 });
            PGenWidgets.Add(new PCMGenWidgetViewModel { Description = "PCM Generator 2", ID=2 });            
        }
