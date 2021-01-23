    Task.Factory.StartNew(
            new Action(delegate()
            {
              ------------------------------
             |  Socket's Code Comes Here  |
              ------------------------------
              Dispatcher.Invoke(
                      new Action(delegate()
                               {
                    if (this.IsUpdateNeeded == true) //IsUpdateNeeded == My Own Variable..
                    {
                               MessageBox.Show("New Version Is Here !", "New Version Is Here !", MessageBoxButtons.OK, .MessageBoxIcon.Information);
                               GoToWebsite();
                    }
                    else
                   {
                       MessageBox.Show("You Own The Latest Version", "No Update Is Needed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                   this.MediaElement.Stop();
                   this.Close();   
                }
               }
              ));
                )
            );
