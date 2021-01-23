     // interface method declaration
     interface IVirtualCameraFilter_Crop
     {
        [PreserveSig]
        int SetImageData([In,MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] _array,[In] int size);
     }
     // Code implementation
     IVirtualCameraFilter_Crop _filter // your filter interface
     BitmapData _data = // your BitmapLock
     int _size = // your image size while you locking it Width * Height * BPP / 8
     byte[] _array = new byte[_size];
     Marshal.Copy(_data.Scan0,_array,0,_size);
     _filter.SetImageData(_array,_size);
     // Passing IntPtr way will be similar just the changes will be in method declaration in interface 
     [PreserveSig]
     int SetImageData([In] IntPtr _array,[In] int size);
     // This way you can just pass the _data.Scan0 value
     // The C++ interface declaration and handler will be same for both ways
     // C++ interface declaration
     DECLARE_INTERFACE(IVirtualCameraFilter_Crop,IUnknown)
     {
         [PreserveSig]
         STDMETHOD(SetImageData)(LPBYTE _array,long size)PURE;
     }
     //C++ implementation
     STDMETHODIMP CFilter::SetImageData(LPBYTE _array,long size)
     {
        CheckPointer(_array,E_POINTER);
        CopyMemory(_internalArray,_array,size);
        return NOERROR;
     }
