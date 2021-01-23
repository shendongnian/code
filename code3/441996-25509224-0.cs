    public string GetString(double valueField)
	{
		char[] ins = valueField.ToString().ToCharArray();
		int length = ins.Length + (ins.Length / 3);
		if (ins.Length % 3 == 0)
		{
			length--;
		}
		char[] outs = new char[length];
		int i = length - 1;
		int j = ins.Length - 1;
		int k = 0;
		do
		{
			if (k == 3)
			{
				outs[i--] = ' ';
				k = 0;
			}
			else
			{
				outs[i--] = ins[j--];
				k++;
			}			
		}
		while (i >= 0);
	
		return new string(outs);
	}
