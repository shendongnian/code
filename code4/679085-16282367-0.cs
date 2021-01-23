	int[] data = ...;
	// start from second byte, to be able to touch the previous one
	int i = 1;
	while (i < data.Length)
	{
		if (data[i-1] == 0x13 && data[i] == 0x10)
		{
			// end of subarray reached
			Console.WriteLine();
			i+=2;
		}
		else
		{
			// output the previous character, won't be used in the next iteration
			Console.Write(data[i-1].ToString("X2"));
			i++;
		}
	}
	// process the last (or the only) byte of the array, if left
	if (i == data.Length)
	{
			// apparently there wasn't a delimiter in the array's last two bytes
			Console.Write(data[i-1].ToString("X2"));
			Console.WriteLine(" - no 0x13 010");
	}
