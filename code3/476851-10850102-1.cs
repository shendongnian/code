    DateTime _lastKeystroke = new DateTime(0);
    List<char> _barcode = new List<char>(10);
    private void Form1_KeyPress(object sender, KeyPressEventArgs e)
    {
        // check timing (keystrokes within 100 ms)
        TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
        if (elapsed.TotalMilliseconds > 100)
            _barcode.Clear();
        // record keystroke & timestamp
        _barcode.Add(e.KeyChar);
        _lastKeystroke = DateTime.Now;
        // process barcode
        if (e.KeyChar == 13 && _barcode.Count > 0) {
            string msg = new String(_barcode.ToArray());
            MessageBox.Show(msg);
            _barcode.Clear();
        }
    }
