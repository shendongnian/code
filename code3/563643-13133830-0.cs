    var sendBuf = new byte[256];
    
    // char in C# is a UTF-16 character (at least 2 bytes). Use byte[] here instead.
    byte[] version = 
    		{
    				(byte)'A', (byte)'U', (byte)'D', (byte)'I', (byte)'E', (byte)'N', (byte)'C', (byte)'E',         // name
    				0, 0, 0, 0, 0, 0, 0, 0,        // reserved,  firmware size
    				0, 0, 0, 0, 0, 0, 0, 0,        // board number
    				0, 0, 0, 0, 0, 0, 0, 0,        // variant, version, serial
    				0, 0, 0, 0, 0, 0, 0, 0         // date code, reserved
    		};
    
    int memloc = 0;
    
    sendBuf[memloc++] = 0;
    sendBuf[memloc++] = 0;
    
    // C# doesn't allow pointer arithmetic with arrays. memcpy's signature is also reversed.
    Array.Copy(
       version,		// Source
       0,			// Index of Source
       sendBuf,		// Destination
       memloc,		// Index of Destination
       8);   		// The first 8 bytes
    memloc += 16;
