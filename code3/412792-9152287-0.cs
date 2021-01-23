    ulong GetNumberParity(string input, bool isEvenParity)
    {
    	ulong tmp = Convert.ToUInt64(input, 2);
    	ulong c = 0;
    	for (int i = 0; i < 64; i++) c += tmp >> i & 1;
    	if(isEvenParity)
    		return Convert.ToUInt64((c % 2 != 0 ? "1" : "0") + input, 2);
    	else
    		return Convert.ToUInt64((c % 2 == 0? "1" : "0") + input, 2);
    }
