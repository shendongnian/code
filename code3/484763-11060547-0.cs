    override public long Seek(long offset, SeekOrigin origin)
    {
       long pos = -1;
    
       switch(origin)
       {
          case SeekOrigin.Begin :
             pos = offset;
             break;
          case SeekOrigin.Current :
             pos = Position + offset;
             break;
          case SeekOrigin.End :
             break;
       }
    
       // We generally disallow seeking of the stream
       // However, in unmanaged code, many people use Seek(0,CURR) to retrieve    // the current position
       // Special case (that is, if Seek does not change position, do not 
       // throw an exception)
       if (pos==Position)
       {
          return pos;
       }
       else
       {
          throw new NotSupportedException("ForwardOnlyEventingReadStream does not support Seek()");
       }
    }
