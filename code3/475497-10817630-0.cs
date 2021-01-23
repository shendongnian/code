    Task.Factory.StartNew(() =>
                {
                   System.Windows.Application.Current.Dispatcher.BeginInvoke((Action)delegate()
                     {
                         Loading = true;
                      });
                    var converterFactory = new ConverterFactory();
                    var converter = converterFactory.CreatePowerPointConverter();
                    _slides = converter.Convert(location).Slides;
                }
