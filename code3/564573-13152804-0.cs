    //util function
    public static void WriteBuffer(BinaryWriter os, byte[] array) {
    			if ((array!=null) && (array.Length > 0) && (array.Length < MAX_BUFFER_SIZE)) {
    				WriteInt(os,array.Length);
    				os.Write(array);
    			} else {
    				WriteEmptyBuffer(os);
    			}
    		}
    //write a string
    public static void WriteString(BinaryWriter os, string value)  {
    			if (value!=null) {
    				byte[] array = System.Text.Encoding.Unicode.GetBytes(value);
    				WriteBuffer(os,array);
    			} else {
    				WriteEmptyBuffer(os);
    			}
    		}
