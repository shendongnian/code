    private bool _isClosing = false;
    void Form_Closing(object sender, EventArgs e) {
        if (_isClosing) return;
    
        _isClosing = true;
       if (_isRunning) {
          // ....Clean up code....
       }
       _isClosing = false;
    }
