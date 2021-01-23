	static Random rand = new Random((int)DateTime.Now.Ticks);
	static int[] partIndices = new int[100];
	static int[] depth = new int[100];
	
	public static String SpinEvenMoreFaster(String text)
	{
		int last = 0;
		StringBuilder builder = new StringBuilder();
		for (int i = 0; i < text.Length; i++)
		{
			if (text[i] == '{')
			{
				int k = 1;
				int j = i + 1;
				int index = 0;
				partIndices[0] = i;
				depth[0] = 1;
				for (; j < text.Length && k > 0; j++)
				{
					if (text[j] == '{')
						k++;
					else if (text[j] == '}')
						k--;
					else if (text[j] == '|')
					{
						if (k == 1)
						{
							partIndices[++index] = j;
							depth[index] = 1;
						}
						else
							depth[index] = k;
					}
				}
				if (k == 0)
				{
					partIndices[++index] = j - 1;
					int part = rand.Next(index);
					builder.Append(text, last, i - last);
					if (depth[part] == 1)
						builder.Append(text, partIndices[part] + 1, partIndices[part + 1] - partIndices[part] - 1);
					else
						builder.Append(SpinEvenMoreFaster(text.Substring(partIndices[part] + 1, partIndices[part + 1] - partIndices[part] - 1)));
					i = j - 1;
					last = j;
				}
			}
		}
		if (last == 0)
			return text;
		builder.Append(text, last, text.Length - last);
		return builder.ToString();
	}
