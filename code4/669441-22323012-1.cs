    // get the CloudblockBlob object
    using(MemoryStream blobStream = new MemoryStream())
    {
        blobObject.DownloadToStream(blobStream);
        using (var csv = new CsvReader(new StreamReader(blobStream)))
        {
            while (csv.Read())
            {
                try
                {
                 //some reading operation
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
                }
            }
            _logger.InfoFormat("Finished {0} reading data #{1}");
        }
    }
