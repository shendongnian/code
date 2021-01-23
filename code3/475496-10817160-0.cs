     var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
     Loading = true;
    Task.Factory.StartNew(() =>
            {
                var converterFactory = new ConverterFactory();
                var converter = converterFactory.CreatePowerPointConverter();
                _slides = converter.Convert(location).Slides;
            }, 
            CancellationToken.None, 
            TaskCreationOptions.LongRunning, 
    here  ----> scheduler).ContinueWith(x =>
                {
                    Loading = false;
                    CurrentSlide = _slides.First();
                }, 
                CancellationToken.None, 
                TaskContinuationOptions.OnlyOnRanToCompletion, 
                scheduler);
