    byte[] arr = new byte[] {
    	Convert.ToByte("11001110", 2),
    	Convert.ToByte("01000100", 2),
    	Convert.ToByte("10100001", 2),
    	};
    
    byte[] arr2 = Auth.ROL_ByteArray(arr, 1);
    			
    string sss = "";
    for (int i = 0; i < arr2.Length; i++)
    	sss += Convert.ToString(arr2[i], 2) + ", ";
    
    Debug.WriteLine(sss);
