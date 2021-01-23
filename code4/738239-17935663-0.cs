    using System.Threading.Tasks;
    ...
    Task.Factory.StartNew(() => {
        for (...) {
            // operation...
            progressBar.Dispatcher.BeginInvoke(() => progressBar.Value = ...);
        }
    });
