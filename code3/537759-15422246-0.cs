        public void Beep()
        {
            int[] sound = {2730, 150, 0, 30, 2730, 150};
            PlaySound(100, sound);
        }
        public bool PlaySound(int volume, int[] data)
        {
	        // length is byte-based
	        int length = data.Length*4;
	        IntPtr p = Marshal.AllocHGlobal(length);
            for (int i = 0; i < data.Length; i ++)
            {
	            Marshal.WriteInt32(p, i*4, data[i]);
            }
  	        NSError error;
            bool result = dtDevice.PlaySound(volume, p, length, out error);
            // free memory before throwing the exception (if any)
            Marshal.FreeHGlobal(p);
            if (error != null)
                throw new Exception(error.LocalizedDescription);
            return result;
        }
