    LPUNKNOWN* punks;   
    HRESULT hr = SafeArrayAccessData(orders, (void**)&punks);
    if (SUCCEEDED(hr))
    {
        long lLBound, lUBound;
        SafeArrayGetLBound(normnames, 1, &lLBound);
        SafeArrayGetUBound(normnames, 1, &lUBound);
        
        long cElements = lUBound - lLBound + 1; 
        for (int i = 0; i < cElements; i++)
        {                              
            LPUNKNOWN punk = punks[i];
            IOrderPtr order(punk);
            long q = order->GetQuantity();            
        }                                       
        SafeArrayUnaccessData(orders);
    }
    SafeArrayDestroy(orders);
