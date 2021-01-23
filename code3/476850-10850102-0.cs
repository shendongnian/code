    DateTime _lastKeystroke = new DateTime(0);
    List<char> barcode = new List<char>(10);
    private void Form1_KeyPress(object sender, KeyPressEventArgs e)
    {
        // check timing
        TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
        if (elapsed.TotalMilliseconds > 100)
            barcode.Clear();
        // record keystroke & timestamp
        barcode.Add(e.KeyChar);
        _lastKeystroke = DateTime.Now;
        // process barcode
        if (e.KeyChar == 13 && barcode.Count > 0) {
            string msg = new String(barcode.ToArray());
            MessageBox.Show(msg);
            barcode.Clear();
        }
    }
