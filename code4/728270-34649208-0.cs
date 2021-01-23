      await Windows.System.Threading.ThreadPool.RunAsync(async (s) =>
            {
               
                await Task.Delay(1);
                await MainViewModel.Instance.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
                {
                MessageBox.Show("after delay");
                 });
                 }, Windows.System.Threading.WorkItemPriority.High);
 
