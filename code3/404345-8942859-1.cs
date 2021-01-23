    private byte[] _image;
    /// <summary>
    /// Bytes for Image. Set to null to delete related file.
    /// </summary>
    public virtual byte[] Image
    {
        get
        {
            if (_image == null)
            {
                if (SaveDirectory == null) throw new ValidationException("SaveDirectory not set for DriverDoc");
                string fullFilename = Path.Combine(SaveDirectory, Filename);
                if (!string.IsNullOrEmpty(fullFilename))
                    if (File.Exists(fullFilename))
                        _image = File.ReadAllBytes(fullFilename);
                    else
                        _image = File.ReadAllBytes("Resources\\FileNotFound.bmp");
            }
            return _image;
        }
        set
        {
            if (_image == value) return;
            _image = value;
            if (SaveDirectory == null) throw new ValidationException("SaveDirectory not set for DriverDoc");
            string fullFilename = Path.Combine(SaveDirectory, Filename);
            if (_image != null)
            {
                if (!string.IsNullOrEmpty(fullFilename))
                {
                    _image = value;
                    File.WriteAllBytes(fullFilename, _image);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(Filename) && File.Exists(fullFilename))
                    File.Delete(fullFilename);
            }
        }
    }
