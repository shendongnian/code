            byte[] data = new byte[1000];
            MemoryStream mem = null;
            try
            {
                mem = new MemoryStream(data);
                using (Bitmap bmp = new Bitmap(mem))
                {
                    mem = null; // <-- this line will make both warning go away
                }
            }
            finally
            {
                if (mem != null)
                {
                    mem.Dispose();
                }
            } 
