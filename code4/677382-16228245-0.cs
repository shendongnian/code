	public partial class AllMethods {
		static T ReadData<T>(String prompt, T value) {
			Console.Write(prompt);
			return (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
		}
		public static void WritingMethod(int timesToInput) {
			using(var sw=new StreamWriter(path, true))
				for(var list=items.ToArray(); timesToInput-->0; ) {
					var inputs=new Dictionary<String, object>();
					for(var i=0; i<list.Length; ++i) {
						var item=list[i];
						var prompt=String.Format(" Enter your {0}: ", item.Key);
						inputs.Add(
							item.Key, AllMethods.ReadData(prompt, item.Value));
					}
					var output=String.Format(format, inputs.Values.ToArray());
					sw.WriteLine(output+Environment.NewLine);
					Console.WriteLine(output);
					Console.ReadLine();
				}
		}
		public static void ReadingMethod() {
			var textFromFile=
				String.Join(Environment.NewLine, File.ReadAllLines(path));
			Console.WriteLine(
				"--Reading The File--"+Environment.NewLine+textFromFile);
			Console.ReadLine();
		}
		static AllMethods() {
			items=new Dictionary<String, object>();
			// add any item with name and type default value
			items.Add("Name", default(String));
			items.Add("ID", default(int));
			items.Add("Age", default(int));
			items.Add("Email", default(String));
			var prompts=items.Select(
				(item, index) => String.Format("{0}: {{{1}}}", item.Key, index));
			format=
				"Thank you for registration! Your Submitted information are: "
				+Environment.NewLine
				+String.Join(Environment.NewLine, prompts.ToArray());
			path="fileone.txt";
		}
		static Dictionary<String, object> items;
		static String format, path;
	}
