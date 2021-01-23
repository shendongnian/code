    if (e.Error != null)
                {
                    MessageBox.Show(msg);
                    busyIndicator.IsBusy = false;
                    IndicatorMessage = "There has been an error"
                    return;
                }
