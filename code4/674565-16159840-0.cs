    using System;
    using System.Text;
    using System.IO.Ports;
    
    namespace MyNamespace
    {
        public class COMSerialPort : IDisposable
        {
            private SerialPort FSerialPort;
            public Boolean Disposed { get; private set; }
    
            //---------------------------------------------------------------------
            public COMSerialPort(String portName, Int32 baudRate, Encoding encode)
            {
                FSerialPort = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);
                
                FSerialPort.NewLine = "\r";
                FSerialPort.Encoding = encode;
                Disposed = false;
            }
            //---------------------------------------------------------------------
            public COMSerialPort(String portName, Int32 baudRate) : this( portName, baudRate, Encoding.ASCII )
            {
            }
            //---------------------------------------------------------------------
            ~COMSerialPort()
            {
                Dispose(false);
            }
            //---------------------------------------------------------------------
            protected void Dispose(Boolean bDisposing)
            {
                lock (this)
                {
                    if (!Disposed)
                    {
                        Disposed = true;
                        GC.SuppressFinalize(this);
    
                        if (bDisposing)
                        {
                            if (FSerialPort != null)
                            {
                                Close();
    
                                FSerialPort.Dispose();
                                FSerialPort = null;
                            }
                        }
                    }
                }
            }
            //---------------------------------------------------------------------
            public void Dispose()
            {
                Dispose(true);
            }
            //---------------------------------------------------------------------
            public void Open()
            {
                if (!FSerialPort.IsOpen) FSerialPort.Open();
            }
            //---------------------------------------------------------------------
            public void Close()
            {
                if (FSerialPort.IsOpen) FSerialPort.Close();
            }
            //---------------------------------------------------------------------
            public void WriteLine(String data)
            {
                if (FSerialPort.IsOpen) FSerialPort.WriteLine(data);
            }
            //---------------------------------------------------------------------
            public void Write(String data)
            {
                if (FSerialPort.IsOpen) FSerialPort.Write(data);
            }
            //---------------------------------------------------------------------
            public void Write(Byte[] data)
            {
                if (FSerialPort.IsOpen) FSerialPort.Write(data, 0, data.Length);
            }
            //---------------------------------------------------------------------
            public String ReadLine()
            {
                String rValue;
                if (FSerialPort.IsOpen)
                    rValue = FSerialPort.ReadLine();
                else
                    rValue = null;
    
                return rValue;
            }
            //---------------------------------------------------------------------
            public String Read(Int32 count)
            {
                String rValue = null;
                if (FSerialPort.IsOpen)
                {
                    Char[] buffer = new Char[count];
                    FSerialPort.Read(buffer, 0, count);
    
                    StringBuilder sb = new StringBuilder();
                    sb.Append(buffer);
    
                    rValue = sb.ToString();
                }
    
                return rValue;
            }
            //---------------------------------------------------------------------
            public Byte[] ReadBytes(Int32 count)
            {
                Byte[] rValue = null;
                if (FSerialPort.IsOpen)
                {
                    rValue = new Byte[count];
                    FSerialPort.Read(rValue, 0, count);
                }
    
                return rValue;
            }
            //---------------------------------------------------------------------
            public Char ReadChar()
            {
                return (Char)FSerialPort.ReadChar();
            }
            //---------------------------------------------------------------------
            public Int32 ReadByte()
            {
                return FSerialPort.ReadByte();
            }
            //---------------------------------------------------------------------
            public SerialPort NativeObject
            {
                get { return FSerialPort; }
            }
        }
    }
