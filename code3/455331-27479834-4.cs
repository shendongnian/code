        #region Contracts
        Contract.Requires(!string.IsNullOrEmpty(fileName));
        Contract.Requires(!string.IsNullOrEmpty(extension));
        Contract.Requires(blockSize > 1);
        #endregion
        const string rtfExtension = ".rtf";
        FileName = fileName;
        Extension = extension;
        BufferSize = blockSize;
        _buffer = new char[ActBufferSize];
        // ! Take into account that Rtf-file can be loaded only using IPersistFile.
        var doUseIPersistFile = string.Compare(rtfExtension, extension, StringComparison.InvariantCultureIgnoreCase) == 0;
        // Initialize _filter instance.
        try
        {
            if (doUseIPersistFile)
            {
                // Load content using IPersistFile.
                _filter = FilterLoader.LoadIFilterFromIPersistFile(FileName, Extension);
            }
            else
            {
                // Load content using IPersistStream.
                using (var stream = new FileStream(path: fileName, mode: FileMode.Open, access: FileAccess.Read, share: FileShare.Read))
                {
                    var buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);
                    _filter = FilterLoader.LoadIFilterFromStream(buffer, Extension);
                }
            }
        }
        catch (FileNotFoundException)
        {
            throw;
        }
        catch (Exception e)
        {
            throw new AggregateException(message: string.Format("Filter Not Found or Loaded for extension '{0}'.", Extension), innerException: e);
        }
