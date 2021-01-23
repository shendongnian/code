    // Split the string into two parts
    string[] strings = textBox1.text.Split(',');
    byte byte1, byte2;
    // Make sure it has only two parts,
    // and parse the string into a byte, safely
    if (strings.Length == 2
        && byte.TryParse(strings[0], System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out byte1)
        && byte.TryParse(strings[1], System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out byte2))
    {
        // Form the bytes to send
        byte[] bytes_to_send = new byte[] { 137, byte1, byte2, 128, 0 };
        // Writes the data to the serial port.
        serialPort1.Write(bytes_to_send, 0, bytes_to_send.Length);
    }
    else
    {
        // Show some kind of error message?
    }
