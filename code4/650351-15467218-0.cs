    using(var stream = new FileStream(...))
    using(var writer = new BinaryWriter(stream)) {
        var bytesLeft = array.Length; // assuming array is an array of bytes
        var bytesWritten = 0;
        while(bytesLeft > 0) {
            var chunkSize = Math.Min(64, bytesLeft);
            writer.WriteBytes(array, bytesWritten, chunkSize);
            bytesWritten += chunkSize;
            bytesLeft -= chunkSize;
            // notify progressbar (assuming you're using a background worker)
            backgroundWorker.ReportProgress(bytesWritten * 100 / array.Length);
        }
    }
