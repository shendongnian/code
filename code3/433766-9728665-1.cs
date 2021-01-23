                BackgroundWorker bw = new BackgroundWorker();
                bw.DoWork += delegate(object s, DoWorkEventArgs we)
                {
                    for (int i = 0; i < resultGrid.Items.Count - 1; i++)
                    {
                        var dto = (GridDto)this.resultGrid.Items[i];
                        var color = Color.FromRgb(192, 192, 25);
                        try
                        {
                            // Do webservice call using the dto data
                        }
                        catch (Exception ex)
                        {
                            dto.Reply = ex.Message;
                            color = Color.FromRgb(255, 0, 0);
                        }
                        dto.Color = new SolidColorBrush(color) { Opacity = 0.45 };
                    }
                };
                bw.RunWorkerAsync();
