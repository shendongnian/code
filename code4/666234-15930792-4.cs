    IsLoading = true;
    Task.Factory.StartNew(() => 
        {
            // run long process and return results in temp variable
            return LoadData();
        })
        .ContinueWith((t) => 
        {
            // this block runs once the background code finishes
            // update with results from temp variable
            UpdateData(t.Result)
            // reset loading flag
            IsLoading = false;
        });
