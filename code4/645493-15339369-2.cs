    	[TestFixture]
	public class TestyMcTest
	{
		public class Vid
		{
			public int CamId;
			public DateTime Start;
			public DateTime End;
		}
		[Test]
		public void Test()
		{
			var list = new List<Vid>
				{
					//=====Combination1=======
					new Vid
						{
							CamId = 1,
							Start = new DateTime(2000, 1, 1, 0, 0, 0),
							End = new DateTime(2000, 1, 1, 0, 3, 0)
						},
					new Vid
						{
							CamId = 1,
							Start = new DateTime(2000, 1, 1, 0, 5, 0),
							End = new DateTime(2000, 1, 1, 0, 7, 0)
						},
					//=====Combination2=======
					new Vid
						{
							CamId = 1,
							Start = new DateTime(2000, 1, 1, 0, 15, 0),
							End = new DateTime(2000, 1, 1, 0, 18, 0)
						},
					//=====Combination3=======
					new Vid
						{
							CamId = 2,
							Start = new DateTime(2000, 1, 1, 0, 0, 0),
							End = new DateTime(2000, 1, 1, 0, 3, 0)
						},
					//=====Combination4=======
					new Vid
						{
							CamId = 2,
							Start = new DateTime(2000, 1, 1, 0, 10, 0),
							End = new DateTime(2000, 1, 1, 0, 13, 0)
						}
				};
			//here is your list of vids grouped by the cam id
			var result = ExtractVidTimes(list);
		}
		//THE METHOD
		private static List<List<Vid>> ExtractVidTimes(List<Vid> list)
		{
			//Group by cam ID
			var vidGroups = list.GroupBy(vid => vid.CamId).ToList();
			//extract vids with aggregate times
			var result = vidGroups.Select(vids =>
				{
					var vidTimes = new List<Vid>();
					var finalVid = vids.OrderBy(vid=> vid.Start).Aggregate((a, b) =>
						{
							if (a.End.AddMinutes(5) > b.Start)
							{
								a.End = b.End;
								return a;
							}
							vidTimes.Add(a);
							return b;
						});
					vidTimes.Add(finalVid);
					return vidTimes;
				}).ToList();
			return result;
		}
	}
