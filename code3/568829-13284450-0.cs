            slider.Value = 3.5;
            incrementSlider.Value = 0.00001;
            EventHandler renderer = (s, e) =>
            {
                if (slider.Value < 10.0)
                    slider.Value += incrementSlider.Value;
                //Title = slider.Value.ToString() + "     " + incrementSlider.Value;
                draw();
                _frameCounter++;
            };
            CompositionTarget.Rendering += renderer;
            pauseButton.Click += (sender, args) => CompositionTarget.Rendering -= renderer;
            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += (s, e) =>
                              {
                                  Title = string.Format("fps: {0}", _frameCounter);
                                  _frameCounter = 0;
                              };
            timer.Start();
