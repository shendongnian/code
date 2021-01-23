	static void Main(string[] args) {
		int number_of_column; // never used
		if(Directory.Exists(path)) {
			var file1=(
				from f in dir.GetFiles()
				orderby f.LastWriteTime
				select f
				).First().ToString();
			Console.WriteLine(file1);
			using(var sr=new StreamReader(Path.Combine(path, file1)))
				for(String line; null!=(line=sr.ReadLine()); ) {
					if(start) {
						var line1=line.Split(',');
						for(var i=0; i<line1.Length; ++i) {
							var s=line1[i];
							if("0"!=s||!String.IsNullOrEmpty(s))
								col[i]="checked";
						}
						continue;
					}
					if(
						line.Contains("Timestamp")
						&&
						line.Contains("LiveStandby")
						&&
						line.Contains("peak"
						))
						start=true;
				}
			for(var i=0; i<col.Length; ++i) {
				// following lines are no more needed
				// if(i<number_of_column-1) {
				// }
			}
		}
	}
