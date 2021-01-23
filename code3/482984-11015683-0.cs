	using System.Collections.Generic;
	using System.Linq;
	
	// ...
	
	public  byte[] HexStringToByteArray(string hex)
		{
			var result = new List<byte>();
			
			for (int i = hex.Length - 1; i >= 0; i -= 2)
				{
					if (i > 0)
						{
							result.Insert(0, Convert.ToByte(hex.Substring(i - 1, 2), 16));
						}
					else
						{
							result.Insert(0, Convert.ToByte(hex.Substring(i, 1), 16));
						}
				}
				
			return bytes.ToArray();
		}
