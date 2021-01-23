    public class MyDataListProvider : IMyDataListProvider
    {
        private <ObservableCollection<IMyData>> myDataList;
        
        public Task<ObservableCollection<IMyData>> GetMyData()
                {
                    TaskCompletionSource<ObservableCollection<IMyData>> taskCompletionSource = new TaskCompletionSource<ObservableCollection<IMyData>>();
        
                    MyWCFClientProxy client = new MyWCFClientProxy();
        
                    this.myDataList.Clear();
        
                    client.GetMyDataCompleted += (o, e) =>
                    {
                        if (e.Error != null)
                        {
                            taskCompletionSource.TrySetException(e.Error);
                        }
                        else
                        {
                            if (e.Cancelled)
                            {
                                taskCompletionSource.TrySetCanceled();
                            }
                            else
                            {
                                foreach (var s in e.Result)
                                {
                                    var item = new MyData();
                                    item.Name = s.Name;
                                    item.Fullname = s.Fullname;
        
                                    this.myDataList.Add(item);
                                }
        
                                taskCompletionSource.TrySetResult(this.myDataList);
                            }
                        }
                    };
        
                    client.GetMyDataAsync();
        
                    return taskCompletionSource.Task;
                }
    }
