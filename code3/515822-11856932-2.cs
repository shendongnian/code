    var sp = new SerialPort("COM1") {
        BaudRate = 9600,
        Parity = Parity.None,
        StopBits = StopBits.One,
        DataBits = 8,
        Handshake = Handshake.None
    };
    sp.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
