    // server-side
    public class ValuesController : ApiController {
		[HttpPost]
		public string PushMessage([FromUri] string x, [FromUri] string y, [FromBody] Person p) {
			return p.ToString();
		}
	}
	public class Person {
		public string Name { get; set; }
		public int Age { get; set; }
		public override string ToString() {
			return this.Name + ": " + this.Age;
		}
	}
    // client-side
    public class Program {
		private static readonly string URL = "http://localhost:6299/api/values/PushMessage?x=asd&y=qwe";
		public static void Main(string[] args) {
			NameValueCollection data = new NameValueCollection();
			data.Add("Name", "Johannes");
			data.Add("Age", "24");
			WebClient client = new WebClient();
			client.UploadValuesCompleted += UploadValuesCompleted;
			client.Headers["Content-Type"] = "application/x-www-form-urlencoded";
			Task t = client.UploadValuesTaskAsync(new Uri(URL), "POST", data);
			t.Wait();
		}
		private static void UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e) {
			Console.WriteLine(Encoding.ASCII.GetString(e.Result));
		}
	}
