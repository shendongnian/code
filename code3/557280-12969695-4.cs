        public PCMGenViewModel()
        {
            PGenWidgets = new ObservableCollection<PCMGenWidgetViewModel>();
            PGenWidgets.Add(new PCMGenWidgetViewModel { Description = "PCM Generator 1", BitMask="BitMask1" });
            PGenWidgets.Add(new PCMGenWidgetViewModel { Description = "PCM Generator 2", BitMask="BitMask2" });            
        }
