    static class Scanner {
      const string _CODEFILE = "Scanner.cs - Scanner::";
      static int _baud = 9600;
      static int _bits = 8;
      static string _dataIn = null;
      static string _port = "COM1";
      static Parity _parity = Parity.None;
      static StopBits _stop = StopBits.One;
      static SerialPort _com1 = null;
      static TextBox _textbox = null;
      public enum ControlType { None, BadgeID, PartNumber, SerialNumber, WorkOrder };
      static ControlType _control;
      public static bool Available { get { return ((_com1 != null) && (_com1.IsOpen)); } }
      public static bool Close {
        get {
          if (_com1 == null) return true;
          try {
            if (_com1.IsOpen) {
              _com1.Close();
            }
            return (!_com1.IsOpen);
          } catch { }
          return false;
        }
      }
      public static string Open() {
        const string na = "Not Available";
        if (_com1 == null) {
          string reset = Reset();
          if (!String.IsNullOrEmpty(reset)) return reset;
        }
        try {
          _com1.Open();
          return (_com1.IsOpen) ? null : na;
        } catch (Exception err) {
          return err.Message;
        }
      }
      static void ProcessData(string incoming) {
        _dataIn += incoming;
        if ((_control != ControlType.None) && (_textbox != null)) {
          bool ok = false;
          string testData = _dataIn.Trim();
          switch (_control) {
            case ControlType.BadgeID:
              if (testData.Length == 6) {
                if (testData != BarCode.LOGOFF) {
                  Regex pattern = new Regex(@"[0-9]{6}");
                  ok = (pattern.Matches(testData).Count == 1);
                } else {
                  ok = true;
                }
              }
              break;
            case ControlType.PartNumber:
              if (testData.Length == 7) {
                Regex pattern = new Regex(@"[BCX][P057][0-9]{5}");
                ok = (pattern.Matches(testData).Count == 1);
              }
              break;
            case ControlType.SerialNumber:
              if (testData.Length == 15) {
                Regex pattern = new Regex(@"[BCX][P057][0-9]{5} [0-9]{4} [0-9]{2}");
                ok = (pattern.Matches(testData).Count == 1);
              }
              break;
            case ControlType.WorkOrder:
              if (testData.Length == 6) {
                Regex pattern = new Regex(@"[0-9]{6}");
                ok = (pattern.Matches(testData).Count == 1);
              }
              break;
          }
          if (ok) {
            _textbox.Text = testData;
            _textbox.ScrollToCaret();
            _dataIn = null;
          }
        }
      }
      static string Reset() {
        if (_com1 != null) {
          try {
            if (_com1.IsOpen) {
              _com1.DiscardInBuffer();
              _com1.Close();
            }
          } catch (Exception err) {
            return err.Message;
          }
          Global.Dispose(_com1);
          _com1 = null;
        }
        try {
          _com1 = new SerialPort(_port, _baud, _parity, _bits, _stop);
          _com1.DataReceived += new SerialDataReceivedEventHandler(Serial_DataReceived);
          _com1.Open();
        } catch (Exception err) {
          return err.Message;
        }
        return null;
      }
      public static void ScanSource(ref TextBox objTextBox, ControlType objType) {
        _textbox = objTextBox;
        _control = objType;
        _dataIn = null;
      }
      static void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e) {
        ProcessData(_com1.ReadExisting());
      }
      public static void Settings(string ComPort, int BaudRate, Parity ParityValue, int Bits, StopBits StopBit) {
        _port = ComPort;
        _baud = BaudRate;
        _parity = ParityValue;
        _bits = Bits;
        _stop = StopBit;
      }
      /// <summary>
      /// Closes the COM Port
      /// COM Port routines are ready to add as soon as I am
      /// </summary>
      static bool ComPortClose {
        get {
          if (_com1 == null) ComPortReset();
          return ((_com1 == null) ? true : _com1.IsOpen ? false : true);
        }
        set {
          if (_com1 == null) ComPortReset();
          else if (_com1.IsOpen) {
            _com1.DiscardInBuffer();
            _com1.Close();
          }
        }
      }
      /// <summary>
      /// Opens the COM Port
      /// </summary>
      static bool ComPortOpen {
        get {
          if (_com1 == null) ComPortReset();
          return (_com1 == null) ? false : _com1.IsOpen;
        }
        set {
          if (_com1 == null) ComPortReset();
          if ((_com1 != null) && (!_com1.IsOpen)) _com1.Open();
        }
      }
      /// <summary>
      /// Initialized the Serial Port on COM1
      /// </summary>
      static void ComPortReset() {
        if ((_com1 != null) && (_com1.IsOpen)) {
          _com1.Close();
          _com1 = null;
        }
        try {
          _com1 = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
        } catch (IOException err) {
          Global.LogError(_CODEFILE + "ComPortReset", err);
        }
      }
    }
