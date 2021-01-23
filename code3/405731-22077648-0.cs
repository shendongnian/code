    public static byte[] GetBytesFrom( object o )
    {
      Type t = o.GetType() ;
      TypeCode tc = Type.GetTypeCode(t) ;
      byte[] bytes ;
      
      switch( tc )
      {
      case TypeCode.Boolean  : bytes = BitConverter.GetBytes( (bool)   o ) ; break ;
      case TypeCode.Char     : bytes = BitConverter.GetBytes( (char)   o ) ; break ;
      case TypeCode.Double   : bytes = BitConverter.GetBytes( (double) o ) ; break ;
      case TypeCode.Single   : bytes = BitConverter.GetBytes( (float)  o ) ; break ;
      case TypeCode.Int16    : bytes = BitConverter.GetBytes( (short)  o ) ; break ;
      case TypeCode.Int32    : bytes = BitConverter.GetBytes( (int)    o ) ; break ;
      case TypeCode.Int64    : bytes = BitConverter.GetBytes( (long)   o ) ; break ;
      case TypeCode.UInt16   : bytes = BitConverter.GetBytes( (ushort) o ) ; break ;
      case TypeCode.UInt32   : bytes = BitConverter.GetBytes( (uint)   o ) ; break ;
      case TypeCode.UInt64   : bytes = BitConverter.GetBytes( (ulong)  o ) ; break ;
      // not directly supported by BitConverter, but just for kicks, we'll throw it in.
      case TypeCode.SByte    : bytes = new []{ (byte)o }                   ; break ;
      case TypeCode.Byte     : bytes = new []{ (byte)o }                   ; break ;
      default : throw new InvalidOperationException("Can't get bytes from type {0}" , t.
      }
      return bytes ;
    }
