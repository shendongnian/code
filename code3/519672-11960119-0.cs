        using System.Net.NetworkInformation;
        using System.Diagnostics; // for demo purposes only
        public void BUTTON_CLICK(...)
        {
            Ping pingSender = new Ping ();
            PingOptions options = new PingOptions ();
            // Use the default Ttl value which is 128,
            // but change the fragmentation behavior.
            options.DontFragment = true;
            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes (data);
            int timeout = 120;
            string ipOrHost = "80.108.20.100"; // or access your textbox
            //string ipOrHost = txtIP.Text;
            PingReply reply = pingSender.Send (ipOrHost, timeout, buffer, options);
            if (reply.Status == IPStatus.Success)
            {
                Debug.WriteLine ("Address: {0}", reply.Address.ToString ());
                Debug.WriteLine ("RoundTrip time: {0}", reply.RoundtripTime);
                Debug.WriteLine ("Time to live: {0}", reply.Options.Ttl);
                Debug.WriteLine ("Don't fragment: {0}", reply.Options.DontFragment);
                Debug.WriteLine ("Buffer size: {0}", reply.Buffer.Length);
            }
        }
