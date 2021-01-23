    public override long Length
    {
        get
        {
            this.EnsureNotClosed();
            if (this._writePos > 0)
            {
                this.FlushWrite();
            }
            return this._stream.Length;
        }
    }
