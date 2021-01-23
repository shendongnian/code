	static int getnum15(RNGCryptoServiceProvider RngCsp)
	{
		byte[] p=new byte[1];
		do {
			RngCsp.GetBytes(p);
		} while (p[0]==255);
		return(p[0]%15);
	}
