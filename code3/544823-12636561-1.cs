	public class PageChecker
	{
		public IDictionary<int, bool> PositionAndChecked { get; set; }
		public PageChecker()
		{
			SetUpPages();
		}
		private void SetUpPages()
		{
			PositionAndChecked = new Dictionary<int, bool>();
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
