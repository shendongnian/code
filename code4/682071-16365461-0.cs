			var list1 = new List<int> {10, 20, 30};
			var list2 = new List<int> {1, 2, 3};
			int i = 0;
			foreach (int integ in list1)
			{
				foreach (int integ2 in list2)
				{
					switch (i)
					{
						case 0:
							Console.WriteLine(integ + integ2);
							break;
						case 1:
							Console.WriteLine(integ + integ2);
							break;
						default:
							Console.WriteLine(integ + integ2);
							break;
					}
				}
				i++;
				Console.WriteLine(i);
			}
