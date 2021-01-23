	class PageChecker
	{
		Dictionary<int, bool> PositionAndChecked { get; set; }
		public PageChecker()
		{
			SetUpPages();
		}
		private void SetUpPages()
		{
			var pageCount = 10;
			for (int i = 0; i < pageCount; i++)
			{
				PositionAndChecked.Add(i, false);
			}
		}
		public void CheckPage(int pageNo)
		{
			PositionAndChecked[pageNo] = true;
		}
	}
