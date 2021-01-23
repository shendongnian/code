	public class Play {
		enum ReaderCommand {
			Read,
			Close
		}
		delegate string ColumnReader(ReaderCommand cmd);
		static ColumnReader GetColumnReader(string filename) {
			TextReader reader = new StreamReader(filename);
			var headers = reader.ReadLine();
			return (ReaderCommand cmd) => {
				switch (cmd) {
					case ReaderCommand.Read:
						return reader.ReadLine();
					case ReaderCommand.Close:
						reader.Dispose();
						return null;
				}
				return null;
			};
		}
		public static void Main(string[] args) {
			var Reader = GetColumnReader("Input.tsv");
			Console.WriteLine(Reader(ReaderCommand.Read));
			Console.WriteLine(Reader(ReaderCommand.Read));
			Reader(ReaderCommand.Close);
			Console.ReadKey();
		}
	}
