    Task.Factory.ContinueWhenAll(tasks.ToArray(),
          result =>
          {
              var time = watch.ElapsedMilliseconds;
              this.Dispatcher.BeginInvoke(new Action(() =>
                  label1.Content += time.ToString()));
          });  
