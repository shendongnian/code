    //
    // Summary:
    //     Sends a UDP datagram to a specified port on a specified remote host.
    //
    // Parameters:
    //   dgram:
    //     An array of type System.Byte that specifies the UDP datagram that you intend
    //     to send represented as an array of bytes.
    //
    //   bytes:
    //     The number of bytes in the datagram.
    //
    //   hostname:
    //     The name of the remote host to which you intend to send the datagram.
    //
    //   port:
    //     The remote port number with which you intend to communicate.
    //
    // Returns:
    //     The number of bytes sent.
    //
    public int Send(byte[] dgram, int bytes, string hostname, int port);
