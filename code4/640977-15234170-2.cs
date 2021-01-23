		using System.Collections;
		using System.IO;
		using System;
		using System.Collections.Generic;
		using System.Linq;
		using System.Text;
		public partial class Permutation {
			public static Permutation FromFile(String path) {
				return new Permutation(path);
			}
			public static String GetSortedAlphabet(String text) {
				var array=text.ToArray();
				Array.Sort(array);
				return new String(array);
			}
			public Dictionary<String, String> Dictionary {
				private set;
				get;
			}
			public FileInfo SourceFile {
				private set;
				get;
			}
			public Permutation(String path) {
				this.Dictionary=(
					from line in File.ReadAllLines(path)
					where false==String.IsNullOrEmpty(line)
					group line by Permutation.GetSortedAlphabet(line) into g
					select
						new {
							Value=String.Join(", ", g.Distinct().ToArray()),
							Key=g.Key
						}
					).ToDictionary(x => x.Key, x => x.Value);
				this.SourceFile=new FileInfo(path);
			}
		}
		namespace ConsoleApplication1 {
			partial class Program {
				static void ProcessLine(IList<char> input) {
					Console.WriteLine();
					if(input.Count>0) {
						var inputArray=input.ToArray();
						var key=Permutation.GetSortedAlphabet(new String(inputArray));
						var dict=Program.Permutation.Dictionary;
						var hasKey=dict.ContainsKey(key);
						var source=Permutation.SourceFile;
						Console.WriteLine("Possible permutations are: ");
						foreach(var sequence in (Permutable<char>)inputArray)
							Console.WriteLine("{0}", new String(sequence.ToArray()));
						Console.WriteLine("Acceptable in file '{0}' are: ", source.FullName);
						Console.WriteLine("{0}", hasKey?dict[key]:"<none>");
						Console.WriteLine();
						input.Clear();
					}
					Console.Write(Prompt);
				}
				static void ProcessChar(IList<char> input, char keyChar) {
					Console.Write(keyChar);
					input.Add(keyChar);
				}
				static void ProcessExit(IList<char> input, char keyChar) {
					Console.WriteLine();
					Console.Write("Are you sure to exit? (Press Esc again to exit)");
					input.Add(keyChar);
				}
				static bool ProcessLast(IList<char> input, char keyChar) {
					var last=input.Count-1;
					if(0>last||input[last]!=(char)ConsoleKey.Escape)
						return false;
					input.Clear();
					return true;
				}
				public static Permutation Permutation {
					private set;
					get;
				}
				public static String Prompt {
					private set;
					get;
				}
			}
			partial class Program {
				static void Main(String[] args) {
					Console.BufferHeight=short.MaxValue-1;
					Console.SetWindowSize(120, 40);
					ConsoleHelper.CenterScreen();
					var input=new List<char>(char.MaxValue);
					Program.Permutation=Permutation.FromFile(@"c:\dictionary.txt");
					Program.Prompt="User>\x20";
					Program.ProcessLine(input);
					for(; ; ) {
						var keyInfo=Console.ReadKey(true);
						var keyChar=keyInfo.KeyChar;
						var keyCode=keyInfo.Key;
						if(ConsoleKey.Escape==keyCode) {
							if(Program.ProcessLast(input, keyChar))
								break;
							Program.ProcessExit(input, keyChar);
						}
						if(ConsoleKey.Enter==keyCode) {
							if(Program.ProcessLast(input, keyChar))
								Console.WriteLine();
							Program.ProcessLine(input);
							continue;
						}
						if(default(ConsoleModifiers)!=keyInfo.Modifiers)
							continue;
						if(0x1f>keyChar||keyChar>0x7f)
							continue;
						Program.ProcessChar(input, keyChar);
					}
				}
			}
		}
