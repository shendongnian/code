    using System.Web.Mvc;
    using NUnit.Framework;
    namespace StackOverflowSandbox
    {
	[TestFixture]
	public class FileStreamResultTest
	{
		public FileStreamResult DownloadEntries(int id)
		{
			// fake data
			var entries = new[] {new CompetitionEntry { User = new Competitor { FirstName = "Joe", LastName = "Smith", Email = "jsmith@example.com", Id=id.ToString(), PreferredContactNumber = "555-1212"}}};
			using (var stream = new MemoryStream())
			{
				using (var csvWriter = new StreamWriter(stream, Encoding.UTF8))
				{
					csvWriter.WriteLine("First name,Second name,E-mail address,Preferred contact number,UserId\r\n");
					foreach (CompetitionEntry entry in entries)
					{
						csvWriter.WriteLine(String.Format("{0},{1},{2},{3},{4}",
						                                  entry.User.FirstName,
						                                  entry.User.LastName,
						                                  entry.User.Email,
						                                  entry.User.PreferredContactNumber,
						                                  entry.User.Id));
					}
					csvWriter.Flush();
				}
				return new FileStreamResult(new MemoryStream(stream.ToArray()), "text/plain");
			}
		}
		[Test]
		public void CanRenderTest()
		{
			var fileStreamResult = DownloadEntries(1);
			string results;
			using (var stream = new StreamReader(fileStreamResult.FileStream))
			{
				results = stream.ReadToEnd();
			}
			Assert.IsNotEmpty(results);
		}
	}
	public class CompetitionEntry
	{
		public Competitor User { get; set; }
	}
	public class Competitor
	{
		public string FirstName;
		public string LastName;
		public string Email;
		public string PreferredContactNumber;
		public string Id;
	}
    }
