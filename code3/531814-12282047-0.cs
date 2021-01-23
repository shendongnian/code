        public static bool IsWintabAvailable()
        {
            IntPtr buf = IntPtr.Zero;
            bool status = false;
            try
            {
                status = (CWintabFuncs.WTInfoA(0, 0, buf) > 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("FAILED IsWintabAvailable: " + ex.ToString());
            }
            return status;
        }
  
