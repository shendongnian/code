    Imports System.Runtime.InteropServices
    Imports System.Runtime.CompilerServices
    Public Class EdgeGestureUtil
    
        Private Shared DISABLE_TOUCH_SCREEN As Guid = New Guid("32CE38B2-2C9A-41B1-9BC5-B3784394AA44")
        Private Shared IID_PROPERTY_STORE As Guid = New Guid("886d8eeb-8cf2-4446-8d02-cdba1dbdcf99")
        Private Shared VT_BOOL As Short = 11
    
    #Region "Structures"
    
        <StructLayout(LayoutKind.Sequential, Pack:=4)> _
        Public Structure PropertyKey
            Public Sub New(guid As Guid, pid As UInt32)
                fmtid = guid
                Me.pid = pid
            End Sub
    
            <MarshalAs(UnmanagedType.Struct)> _
            Public fmtid As Guid
            Public pid As UInteger
        End Structure
    
        <StructLayout(LayoutKind.Explicit)> _
        Public Structure PropVariant
            <FieldOffset(0)> _
            Public vt As Short
            <FieldOffset(2)> _
            Private wReserved1 As Short
            <FieldOffset(4)> _
            Private wReserved2 As Short
            <FieldOffset(6)> _
            Private wReserved3 As Short
            <FieldOffset(8)> _
            Private cVal As SByte
            <FieldOffset(8)> _
            Private bVal As Byte
            <FieldOffset(8)> _
            Private iVal As Short
            <FieldOffset(8)> _
            Public uiVal As UShort
            <FieldOffset(8)> _
            Private lVal As Integer
            <FieldOffset(8)> _
            Private ulVal As UInteger
            <FieldOffset(8)> _
            Private intVal As Integer
            <FieldOffset(8)> _
            Private uintVal As UInteger
            <FieldOffset(8)> _
            Private hVal As Long
            <FieldOffset(8)> _
            Private uhVal As Long
            <FieldOffset(8)> _
            Private fltVal As Single
            <FieldOffset(8)> _
            Private dblVal As Double
            <FieldOffset(8)> _
            Public boolVal As Boolean
            <FieldOffset(8)> _
            Private scode As Integer
            'CY cyVal;
            <FieldOffset(8)> _
            Private [date] As DateTime
            <FieldOffset(8)> _
            Private filetime As System.Runtime.InteropServices.ComTypes.FILETIME
            'CLSID* puuid;
            'CLIPDATA* pclipdata;
            'BSTR bstrVal;
            'BSTRBLOB bstrblobVal;
            <FieldOffset(8)> _
            Private blobVal As Blob
            'LPSTR pszVal;
            <FieldOffset(8)> _
            Private pwszVal As IntPtr
            'LPWSTR 
            'IUnknown* punkVal;
            'IDispatch* pdispVal;
            '        IStream* pStream;
            '        IStorage* pStorage;
            '        LPVERSIONEDSTREAM pVersionedStream;
            '        LPSAFEARRAY parray;
            '        CAC cac;
            '        CAUB caub;
            '        CAI cai;
            '        CAUI caui;
            '        CAL cal;
            '        CAUL caul;
            '        CAH cah;
            '        CAUH cauh;
            '        CAFLT caflt;
            '        CADBL cadbl;
            '        CABOOL cabool;
            '        CASCODE cascode;
            '        CACY cacy;
            '        CADATE cadate;
            '        CAFILETIME cafiletime;
            '        CACLSID cauuid;
            '        CACLIPDATA caclipdata;
            '        CABSTR cabstr;
            '        CABSTRBLOB cabstrblob;
            '        CALPSTR calpstr;
            '        CALPWSTR calpwstr;
            '        CAPROPVARIANT capropvar;
            '        CHAR* pcVal;
            '        UCHAR* pbVal;
            '        SHORT* piVal;
            '        USHORT* puiVal;
            '        LONG* plVal;
            '        ULONG* pulVal;
            '        INT* pintVal;
            '        UINT* puintVal;
            '        FLOAT* pfltVal;
            '        DOUBLE* pdblVal;
            '        VARIANT_BOOL* pboolVal;
            '        DECIMAL* pdecVal;
            '        SCODE* pscode;
            '        CY* pcyVal;
            '        DATE* pdate;
            '        BSTR* pbstrVal;
            '        IUnknown** ppunkVal;
            '        IDispatch** ppdispVal;
            '        LPSAFEARRAY* pparray;
            '        PROPVARIANT* pvarVal;
            '        
    
            ''' <summary>
            ''' Helper method to gets blob data
            ''' </summary>
            Private Function GetBlob() As Byte()
                Dim Result As Byte() = New Byte(blobVal.Length - 1) {}
                Marshal.Copy(blobVal.Data, Result, 0, Result.Length)
                Return Result
            End Function
    
            ''' <summary>
            ''' Property value
            ''' </summary>
            Public ReadOnly Property Value() As Object
                Get
                    Dim ve As VarEnum = vt
                    Select Case ve
                        Case VarEnum.VT_I1
                            Return bVal
                        Case VarEnum.VT_I2
                            Return iVal
                        Case VarEnum.VT_I4
                            Return lVal
                        Case VarEnum.VT_I8
                            Return hVal
                        Case VarEnum.VT_INT
                            Return iVal
                        Case VarEnum.VT_UI4
                            Return ulVal
                        Case VarEnum.VT_LPWSTR
                            Return Marshal.PtrToStringUni(pwszVal)
                        Case VarEnum.VT_BLOB
                            Return GetBlob()
                    End Select
                    Throw New NotImplementedException("PropVariant " + ve.ToString())
                End Get
            End Property
        End Structure
    
        Friend Structure Blob
            Public Length As Integer
            Public Data As IntPtr
    
            'Code Should Compile at warning level4 without any warnings, 
            'However this struct will give us Warning CS0649: Field [Fieldname] 
            'is never assigned to, and will always have its default value
            'You can disable CS0649 in the project options but that will disable
            'the warning for the whole project, it's a nice warning and we do want 
            'it in other places so we make a nice dummy function to keep the compiler
            'happy.
            Private Sub FixCS0649()
                Length = 0
                Data = IntPtr.Zero
            End Sub
        End Structure
    
    #End Region
    
    #Region "Interfaces"
    
        <ComImport, Guid("886D8EEB-8CF2-4446-8D02-CDBA1DBDCF99"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
        Interface IPropertyStore
            <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
            Sub GetCount(<Out> ByRef cProps As UInteger)
    
            <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
            Sub GetAt(<[In]> iProp As UInteger, ByRef pkey As PropertyKey)
    
            <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
            Sub GetValue(<[In]> ByRef key As PropertyKey, ByRef pv As PropVariant)
    
            <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
            Sub SetValue(<[In]> ByRef key As PropertyKey, <[In]> ByRef pv As PropVariant)
    
            <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
            Sub Commit()
    
            <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
            Sub Release()
        End Interface
    
    #End Region
    
    #Region "Methods"
    
        <DllImport("shell32.dll", SetLastError:=True)> _
        Private Shared Function SHGetPropertyStoreForWindow(handle As IntPtr, ByRef riid As Guid, ByRef propertyStore As IPropertyStore) As Integer
        End Function
    
        Public Shared Sub EnableEdgeGestures(ByVal hwnd As IntPtr, ByVal enable As Boolean)
            Dim pPropStore As IPropertyStore = Nothing
            Dim hr As Integer
            hr = SHGetPropertyStoreForWindow(hwnd, IID_PROPERTY_STORE, pPropStore)
            If hr = 0 Then
                Dim propKey As New PropertyKey
                propKey.fmtid = DISABLE_TOUCH_SCREEN
                propKey.pid = 2
                Dim var As New PropVariant
                var.vt = VT_BOOL
                var.boolVal = enable
                pPropStore.SetValue(propKey, var)
                Marshal.FinalReleaseComObject(pPropStore)
            End If
        End Sub
    
    #End Region
    
    End Class
