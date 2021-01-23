    var filter = new HttpBaseProtocolFilter();
    #if DEBUG
        filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.Expired);
        filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.Untrusted);
        filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.InvalidName);
    #endif
    using (var httpClient = new HttpClient(filter)) {
        ...
    }
