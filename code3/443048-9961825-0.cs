    lock (_statusLocker) {
        statusCopy = _status;
        var newStatus = new ProgressStatus(statusCopy.PercentComplete + 10, statusCopy.StatusMessage);
        _status = newStatus;
    }
