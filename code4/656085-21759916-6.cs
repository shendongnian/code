    [
        object,
        uuid(CCB91121-B81E-11D2-AB74-0040054C3719),
        dual,
        helpstring("IOPOSMSR 1.5 Interface"),
        pointer_default(unique)
    ]
    interface IOPOSMSR_1_5 : IDispatch
    {
    // Methods for use only by the Service Object
        [id(1), hidden, helpstring("method SOData")] HRESULT SOData( [in] long Status );
        [id(2), hidden, helpstring("method SODirectIO")] HRESULT SODirectIO( [in] long EventNumber, [in, out] long* pData, [in, out] BSTR* pString );
        [id(3), hidden, helpstring("method SOError")] HRESULT SOError( [in] long ResultCode, [in] long ResultCodeExtended, [in] long ErrorLocus, [in, out] long* pErrorResponse );
        [id(4), hidden, helpstring("method SOOutputCompleteDummy")] HRESULT SOOutputCompleteDummy( [in] long OutputID );
        [id(5), hidden, helpstring("method SOStatusUpdate")] HRESULT SOStatusUpdate( [in] long Data );
        [id(9), hidden, helpstring("method SOProcessID")] HRESULT SOProcessID( [out, retval] long* pProcessID );
