    public Stream Open(
                Stream		outStr,
                char		format,
                string		name,
                long		length,
                DateTime	modificationTime)
            {
    			if (pkOut != null)
    				throw new InvalidOperationException("generator already in open state");
    			if (outStr == null)
    				throw new ArgumentNullException("outStr");
    
    			// Do this first, since it might throw an exception
    			long unixMs = DateTimeUtilities.DateTimeToUnixMs(modificationTime);
    
                byte[] encName = Encoding.GetEncoding(65001).GetBytes(name);
    
    			pkOut = new BcpgOutputStream(outStr, PacketTag.LiteralData,
                    length + 2 + encName.Length + 4, oldFormat);
    
    			WriteHeader(pkOut, format, name, unixMs);
    
    			return new WrappedGeneratorStream(this, pkOut);
            }
