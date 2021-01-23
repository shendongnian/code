        /// <summary>
        /// sync eMail in outlook
        /// </summary>
        /// <param name="pHandle">handle to forground window</param>
        public void syncNow(IntPtr pHandle)
        {
            if (this.account != null)
            {
                Microsoft.WindowsMobile.PocketOutlook.MessagingApplication.Synchronize(this.account);
                SetForegroundWindow(pHandle);
            }
        }
