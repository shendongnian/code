    class BitReader
    {
        int _bit;
        byte _currentByte;
        Stream _stream;
        public BitReader(Stream stream)
        { _stream = stream; }
    
        public bool ReadBit()
        {
          if (_bit == 8 ) 
          {
            _bit = 0;
            _curentByte  = _stream.ReadByte();
          }
          var value = (_curentByte & (1 << _bit)) > 0;
          _bit++;
          return value;
        }
    }
