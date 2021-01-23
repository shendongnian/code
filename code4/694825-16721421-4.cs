    [
      odl,
      uuid(AA950E58-7C6E-4818-8FC9-ADECBC7A8F14),
      version(1.0),
      oleautomation,
      custom(0F21F359-AB84-41E8-9A78-36D110E6D2F9, "CSDllCOMServer.MyIObjects")
    
    ]
    interface MyIObjects : IUnknown {
        [propget]
        HRESULT _stdcall price([out, retval] single* pRetVal);
        [propput]
        HRESULT _stdcall price([in] single pRetVal);
        [propget]
        HRESULT _stdcall size([out, retval] long* pRetVal);
        [propput]
        HRESULT _stdcall size([in] long pRetVal);
    };
