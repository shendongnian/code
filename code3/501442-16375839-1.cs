    public void ForEach(Action<T> action) {
        if( action == null) {
            ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
        }
        Contract.EndContractBlock();
        int version = _version;
        for(int i = 0 ; i < _size; i++) {
            if (version != _version && BinaryCompatibility.TargetsAtLeast_Desktop_V4_5) {
                break;
            }
            action(_items[i]);
        }
        if (version != _version && BinaryCompatibility.TargetsAtLeast_Desktop_V4_5)
            ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EnumFailedVersion);
    }
