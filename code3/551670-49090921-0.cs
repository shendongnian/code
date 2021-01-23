	int[,] rawNodes = new int[,]
	{
		{ 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0 }
	};
	private void Start()
	{
		int rowLength = rawNodes.GetLength(0);
		int colLength = rawNodes.GetLength(1);
		string arrayString = "";
		for (int i = 0; i < rowLength; i++)
		{
			for (int j = 0; j < colLength; j++)
			{
				arrayString += string.Format("{0} ", rawNodes[i, j]);
			}
			arrayString += System.Environment.NewLine + System.Environment.NewLine;
		}
		Debug.Log(arrayString);
	}
