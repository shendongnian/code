    public class WebClientProgressManager : INotifyPropertyChanged
            {
                private readonly Dictionary<WebClient,int> _clients = new Dictionary<WebClient, int>();
                private const string TotalProgressPropertyName = "TotalProgress";
                public void Add(WebClient client)
                {
                    if (client == null)
                        throw new ArgumentNullException("client");
                    if (_clients.ContainsKey(client)) return;
    
                    client.DownloadProgressChanged += (s, e) =>
                                                          {
                                                              if (e.ProgressPercentage == 100)
                                                              {
                                                                  _clients.Remove((WebClient)s);
                                                              }
                                                              RaisePropertyChanged(TotalProgressPropertyName);
                                                          };
                    _clients.Add(client,0);
    
                }
    
                private void RaisePropertyChanged(string propertyName)
                {
                    if (PropertyChanged != null)
                    {
                        PropertyChanged.Invoke(this,new PropertyChangedEventArgs(propertyName));
                    }
                }
    
                public int TotalProgress
                {
    
                    get
                    {
                        if (_clients.Count == 0) return 100; //need something here to prevent divide-by-zero 
                        int progress = _clients.Sum(client => client.Value);
                        return progress/_clients.Count;
                    }
                }
    
                #region Implementation of INotifyPropertyChanged
    
                public event PropertyChangedEventHandler PropertyChanged;
    
                #endregion
            }
