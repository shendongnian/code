        public PCMGenViewModel()
        {
            PGenWidgets = new ObservableCollection<PCMGenWidgetViewModel>();
            PGenWidgets.Add(new PCMGenWidgetViewModel { Description = "PCM Generator 1", BitMask="0xCF" });
            PGenWidgets.Add(new PCMGenWidgetViewModel { Description = "PCM Generator 2", BitMask="0x3F" });            
        }
