	public static int[] mergeSort(int[] ar)
	{
		Func<int[], int[]> firstHalf = (array) =>
		 {
			 return array.Take((array.Length + 1) / 2).ToArray();
		 };
		Func<int[], int[]> secondHalf = (array) =>
		{
			return array.Skip((array.Length + 1) / 2).ToArray();                
		};
		Func<int[], int[], int[]> mergeSortedArrays = (ar1, ar2) =>
		{
			int[] mergedArray = new int[ar1.Length + ar2.Length];
			int i1 = 0, i2 = 0, currentMin;
			while (i1 < ar1.Length || i2 < ar2.Length)
			{
				if (i1 < ar1.Length && i2 < ar2.Length)
				{
					if (ar1[i1] < ar2[i2])
					{
						currentMin = ar1[i1];
						i1++;
					}
					else
					{
						currentMin = ar2[i2];
						i2++;
					}
				}
				else if (i1 < ar1.Length)
				{
					currentMin = ar1[i1];
					i1++;
				}
				else
				{
					currentMin = ar2[i2];
					i2++;
				}
				mergedArray[i1 + i2 - 1] = currentMin;
			}
			return mergedArray;
		};
		int[] half1 = firstHalf(ar); //always /geq than half2
		int[] half2 = secondHalf(ar);
		if (half1.Length < 2)
			return mergeSortedArrays(half1, half2);
		else
			return mergeSortedArrays(mergeSort(half1), mergeSort(half2));
	}
