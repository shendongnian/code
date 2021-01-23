    _logger.Debug("This message is not indented");
    using (new LogScope(_logger))
    {
        // Anything logged within the using block will be indented
        _logger.Debug("This message is indented");
        using (new LogScope(_logger))
        {
            // LogScopes can be nested such that logging here will be double-indented
            _logger.Debug("This message is double-indented");
        }
        _logger.Debug("This message is back to single-indent");
    }
    // Logging here will revert to the original indent
    _logger.Debug("This message is not indented");
