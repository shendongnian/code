			List<string> strings = new List<string>();
			private string TestString(string word)
			{
				return strings.IndexOf(word) >= 0 ? strings[strings.IndexOf(word)] : null;
			}
			private void Main()
			{
				strings.AddRange(new string[] { "one", "two", "three", "onetwothree" });
				string[] words = { "onethree", "one", "onetwo", "five", "onetwothree" };
				Console.WriteLine(TestString(words[0]));
				Console.WriteLine(TestString(words[1]));
				Console.WriteLine(TestString(words[2]));
				Console.WriteLine(TestString(words[3]));
				Console.WriteLine(TestString(words[4]));
			}
