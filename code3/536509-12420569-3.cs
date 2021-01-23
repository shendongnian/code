    // this would slighlty differ if you use array of VARIANTs
    // but the logic is the same
    LPUNKNOWN* punks;   
    HRESULT hr = SafeArrayAccessData(orders, (void**)&punks);
    if (SUCCEEDED(hr))
    {
        long lLBound, lUBound;
        SafeArrayGetLBound(orders, 1, &lLBound);
        SafeArrayGetUBound(orders, 1, &lUBound);
        
        long cElements = lUBound - lLBound + 1; 
        for (int i = 0; i < cElements; i++)
        {                              
            LPUNKNOWN punk = punks[i]; // for VARIANTs: punk = punks[i].punkVal
            IOrderPtr order(punk); // a smartptr, so it's not 'IOrderPtr*'
            // without smart ptrs, it would be something like:
            // IOrder* pOrder;
            // punk->QueryInterface(IID(IOrder), &pOrder)
            // use it:
            long q = order->GetQuantity();            
            // with smartptrs, order will be properly released
            // with plain COM pointers you need pOrder->Release()
        }       
        SafeArrayUnaccessData(orders);
    }
    SafeArrayDestroy(orders);
