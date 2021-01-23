		static int[] partIndices = new int[100];
		static int[] depth = new int[100];
		static char[] symbolsOfTextProcessed = new char[100000];
		public static String SpinEvenMoreFaster(String text)
		{
			int cur = SpinEvenMoreFasterInner(text, 0, text.Length, 0);
			return new String(symbolsOfTextProcessed, 0, cur);
		}
		public static int SpinEvenMoreFasterInner(String text, int start, int end, int symbolIndex)
		{
			int last = start;
			for (int i = start; i < end; i++)
			{
				if (text[i] == '{')
				{
					int k = 1;
					int j = i + 1;
					int index = 0;
					partIndices[0] = i;
					depth[0] = 1;
					for (; j < end && k > 0; j++)
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
						text.CopyTo(last, symbolsOfTextProcessed, symbolIndex, i - last);
						symbolIndex += i - last;
						if (depth[part] == 1)
						{
							text.CopyTo(partIndices[part] + 1, symbolsOfTextProcessed, symbolIndex, partIndices[part + 1] - partIndices[part] - 1);
							symbolIndex += partIndices[part + 1] - partIndices[part] - 1;
						}
						else
						{
							symbolIndex = SpinEvenMoreFasterInner(text, partIndices[part] + 1, partIndices[part + 1], symbolIndex);
						}
						i = j - 1;
						last = j;
					}
				}
			}
			text.CopyTo(last, symbolsOfTextProcessed, symbolIndex, end - last);
			return symbolIndex + end - last;
		}
