    public void ByteArrayToFile(string _FileName, byte[] _ByteArray, int _BytesRead)
    {
        using (var _FileStream = new FileStream(
          _FileName, FileMode.Append, FileAccess.Write))
        { 
            _FileStream.Write(_ByteArray, 0, _BytesRead);
        }
    }
