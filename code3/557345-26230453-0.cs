    void SendCamData() {
            SendCamSearch();
            ReceiveCams();
        }
    void SendCamSearch() {
            udpC = new UdpClient();
            try {
                udpC.Send(MessForCamsByte, MessForCamsByte.Length, CamsIpEndPoint);
            } catch (Exception e) {
                Console.WriteLine("Blad wysylanie search cam - " + e.ToString());
            }
        }
        void ReceiveCams() {
            if (udpC != null) {
                listener = new Thread(UdpReceiveThread);
                listener.IsBackground = true;
                listener.Start();
                listener.Join(2000);
                SendCamIpAndPort(CamsValsBuilder.ToString());
            }
        }
