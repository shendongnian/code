    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CRYPTUI_VIEWCERTIFICATE_STRUCT
    {
        public int dwSize;
        public IntPtr hwndParent;
        public int dwFlags;
        [MarshalAs(UnmanagedType.LPWStr)]
        public String szTitle;
        public IntPtr pCertContext;
        public IntPtr rgszPurposes;
        public int cPurposes;
        public IntPtr pCryptProviderData;
        public Boolean fpCryptProviderDataTrustedUsage;
        public int idxSigner;
        public int idxCert;
        public Boolean fCounterSigner;
        public int idxCounterSigner;
        public int cStores;
        public IntPtr rghStores;
        public int cPropSheetPages;
        public IntPtr rgPropSheetPages;
        public int nStartPage;
    }
    public static class CryptAPI
    {
        public static void ShowCertificateDialog(X509Chain chain, string title, IntPtr parent)
        {
            const int certStoreProvMemory = 2;      // CERT_STORE_PROV_MEMORY
            const int certCloseStoreCheckFlag = 2;  // CERT_CLOSE_STORE_CHECK_FLAG
            const uint certStoreAddAlways = 4;      // CERT_STORE_ADD_ALWAYS
            const uint x509AsnEncoding = 1;         // X509_ASN_ENCODING
            var storeHandle = CertOpenStore(certStoreProvMemory, 0, 0, 0, null);
            if (storeHandle == IntPtr.Zero)
                throw new Win32Exception();
            try
            {
                foreach (var element in chain.ChainElements)
                {
                    var certificate = element.Certificate;
                    var certificateBytes = certificate.Export(X509ContentType.Cert);
                    var certContextHandle = CertCreateCertificateContext(
                        x509AsnEncoding, certificateBytes, (uint)certificateBytes.Length);
                    if (certContextHandle == IntPtr.Zero)
                        throw new Win32Exception();
                    CertAddCertificateContextToStore(storeHandle, certContextHandle, certStoreAddAlways, IntPtr.Zero);
                }
                var extraStoreArray = new[] { storeHandle };
                var extraStoreArrayHandle = GCHandle.Alloc(extraStoreArray, GCHandleType.Pinned);
                try
                {
                    var extraStorePointer = extraStoreArrayHandle.AddrOfPinnedObject();
                    var viewInfo = new CRYPTUI_VIEWCERTIFICATE_STRUCT();
                    viewInfo.hwndParent = parent;
                    viewInfo.dwSize = Marshal.SizeOf(viewInfo);
                    viewInfo.pCertContext = chain.ChainElements[0].Certificate.Handle;
                    viewInfo.szTitle = title;
                    viewInfo.nStartPage = 0;
                    viewInfo.cStores = 1;
                    viewInfo.rghStores = extraStorePointer;
                    var fPropertiesChanged = false;
                    CryptUIDlgViewCertificate(ref viewInfo, ref fPropertiesChanged);
                }
                finally
                {
                    if (extraStoreArrayHandle.IsAllocated)
                        extraStoreArrayHandle.Free();
                }
            }
            finally
            {
                CertCloseStore(storeHandle, certCloseStoreCheckFlag);
            }
        }
        [DllImport("CRYPT32", EntryPoint = "CertOpenStore", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr CertOpenStore(int storeProvider, int encodingType, int hcryptProv, int flags, string pvPara);
        [DllImport("crypt32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CertCreateCertificateContext([In] uint dwCertEncodingType, [In] byte[] pbCertEncoded, [In] uint cbCertEncoded);
        [DllImport("crypt32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool CertAddCertificateContextToStore([In] IntPtr hCertStore, [In] IntPtr pCertContext, [In] uint dwAddDisposition, [In, Out] IntPtr ppStoreContext);
        [DllImport("crypt32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool CertFreeCertificateContext([In] IntPtr pCertContext);
        [DllImport("CRYPT32", EntryPoint = "CertCloseStore", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern bool CertCloseStore(IntPtr storeProvider, int flags);
        [DllImport("CryptUI.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool CryptUIDlgViewCertificate(ref CRYPTUI_VIEWCERTIFICATE_STRUCT pCertViewInfo, ref bool pfPropertiesChanged);
    }
