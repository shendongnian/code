        [DllImport("ws2_32.dll", SetLastError = true)]
        private static extern SocketError WSAIoctl([In] IntPtr socketHandle, uint ioControlCode, [In] byte[] inBuffer, int inBufferSize, [Out] byte[] outBuffer, int outBufferSize, out int bytesTransferred, IntPtr overlapped, IntPtr completionRoutine);
        /// <summary>Get local IP-address for remote address</summary>
        /// <param name="remoteAddress">Remote Address</param>
        /// <returns></returns>
        public static IPAddress GetLocalAddressForRemote(IPAddress remoteAddress)
        {
            if (remoteAddress == null) return null;
            long rm = remoteAddress.Address;
            //Temporary socket only for handle of it
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            byte[] src = new byte[16];
            src[0] = 2;
            src[4] = (byte)rm;
            src[5] = (byte)(rm >> 8);
            src[6] = (byte)(rm >> 16);
            src[7] = (byte)(rm >> 24);
            int transeferred = 0;
            if (WSAIoctl(s.Handle, 3355443220, src, 16, src, 16, out transeferred, IntPtr.Zero, IntPtr.Zero) == SocketError.Success)
            {
                s.Dispose();
                rm = src[4];
                rm |= ((long)src[5]) << 8;
                rm |= ((long)src[6]) << 16;
                rm |= ((long)src[7]) << 24;
                return new IPAddress(rm);
            }
            s.Dispose();
            return null;
        }
