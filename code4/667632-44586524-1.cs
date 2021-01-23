        private bool CanOpenPDFFiles
        {
            get
            {
                bool CLSIDpresent = false;
                try
                {
                    using (Microsoft.Win32.RegistryKey applicationPDF = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(@"MIME\Database\Content Type\application/pdf"))
                    {
                        if (applicationPDF != null)
                        {
                            var CLSID = applicationPDF.GetValue("CLSID");
                            if (CLSID != null)
                            {
                                CLSIDpresent = true;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                }
                return CLSIDpresent;
            }
        }
