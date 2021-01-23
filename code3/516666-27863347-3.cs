    public Task<string> ProcessRequest(CancellationToken cancellationToken)
    {
        var readTask = Task.Run(() =>
        {
            using (var textFile = File.OpenText("file.txt"))
            {
                var text = textFile.ReadToEnd();
                cancellationToken.ThrowIfCancellationRequested();
                var processedText = text.Replace("foo", "bar");
                return processedText;
            }
        });
        return readTask;
    }
