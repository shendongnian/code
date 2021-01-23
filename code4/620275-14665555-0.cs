    public async Task AddFileAsync(string path)
    {
      // Do some IO
      var ioResult = await DoIoAsync(path);
      // Do some computation
      var computationResult = await Task.Run(() => DoComputation(ioResult));
      // Update Data
      Data.Add(computationResult);
    } 
