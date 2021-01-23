    private bool IsOnline() {
        try
            IPHostEntry dummy = Dns.GetHostEntry("www.google.com"); //using System.Net;
            return true;
        } catch (SocketException ex) {
            return false;
        }
    }
