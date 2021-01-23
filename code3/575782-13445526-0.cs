            IObservable<EventPattern<MouseEventArgs>> mouseMoves =
                Observable
                    .FromEventPattern<MouseEventHandler, MouseEventArgs>(
                        h => richTextBox1.MouseMove += h,
                        h => richTextBox1.MouseMove -= h);
