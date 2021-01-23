    //uses 8 byte
	DateTime tDate = DateAndTime.Now;
	long dtVal = tDate.ToBinary();
	//64bit binary
	byte[] Bits = BitConverter.GetBytes(tDate.ToBinary());
	//your byte output
	//reverse
	long nVal = BitConverter.ToInt64(Bits, 0);
	//get 64bit binary
	DateTime nDate = DateTime.FromBinary(nVal);
	//convert it to date 
