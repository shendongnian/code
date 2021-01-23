        using System.Net.NetworkInformation;
        using System.Diagnostics; // for demo purposes only
        private void PingCommand_Click(object sender, EventArgs e)
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
                Debug.WriteLine ("Address: " + reply.Address.ToString ());
                Debug.WriteLine ("RoundTrip time: " + reply.RoundtripTime);
                Debug.WriteLine ("Time to live: " + reply.Options.Ttl);
                Debug.WriteLine ("Don't fragment: " + reply.Options.DontFragment);
                Debug.WriteLine ("Buffer size: " + reply.Buffer.Length);
            }
        }
