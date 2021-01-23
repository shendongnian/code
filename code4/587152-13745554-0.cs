            int[] arr = new int[30];
			Random rand = new Random(100);
			int maxCount = 0, curCount, value = 0;			
			
			for (int i = 0; i < arr.Length; i++)
				arr[i] = rand.Next(15);				
			arr = arr.OrderBy(a => a).ToArray();
			for (int i = 0; i < arr.Length; i++)
			{
				curCount = 1;
				for (int j = i+1; j < arr.Length-1; j++)
				{
					if (arr[i] == arr[j])
						curCount++;
					else
						break;
				}
				if (curCount > maxCount)
				{
					maxCount = curCount;
					value = arr[i];
					i += maxCount;
				}
			}
