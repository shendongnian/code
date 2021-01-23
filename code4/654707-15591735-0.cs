    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    
    namespace Program
    {
    	public class Class1
    	{
    		public class Program
    		{
    			public static void Main(string[] args)
    			{
    				var hymnFiles = new List<string>()
    				{
    					@"C:\HymnWords.txt",
    					@"C:\HymnWords1.txt",
    					@"C:\HymnWords2.txt",
    					@"C:\HymnWords3.txt",
    				};
    				var reader = new Class1();
    				foreach (var hymn in reader.ReadHymnFiles(hymnFiles))
    				{
    					Console.Out.WriteLine(hymn.Title);
    					foreach (var verse in hymn.Verses)
    					{
    						Console.Out.WriteLine(verse.VerseNumber);
    						foreach (var verseLine in verse.VerseLines)
    						{
    							Console.Out.WriteLine(verseLine);
    						}
    					}
    				}
    				Console.ReadLine();
    			}
    
    		}
    		public List<Hymn> ReadHymnFiles(List<string> hymnFiles)
    		{
    			var hymns = new List<Hymn>();
    			foreach (var hymnFile in hymnFiles)
    			{
    				using (TextReader reader = new StreamReader(hymnFile))
    				{
    					var hymn = new Hymn();
    					hymns.Add(hymn);
    					string line;
    					int currentVerseNumber = 0;
    					while ((line = reader.ReadLine()) != null)
    					{
    						if (string.IsNullOrWhiteSpace(line))
    							continue;
    
    						if (line.Any(char.IsLetter) && line.Any(char.IsDigit))
    						{
    							// this must be the title
    							hymn.Title = line;
    							continue;
    						}
    
    						if (line.Any(c => char.IsDigit(c) && c != 0) && !line.Any(char.IsLetter))
    						{
    							//this must be the verse number
    							currentVerseNumber = Convert.ToInt32(line.Trim());
    							hymn.Verses.Add(new Verse(currentVerseNumber));
    							continue;
    						}
    
    						//get the current verse to add the next line to it
    						var verse = hymn.Verses.Single(v => v.VerseNumber == currentVerseNumber);
    						verse.VerseLines.Add(line);
    					}
    				}
    			}
    			return hymns;
    		}
    
    		public class Hymn
    		{
    			public Hymn()
    			{
    				Verses = new List<Verse>();
    			}
    			public string Title { set; get; }
    			public List<Verse> Verses { set; get; }
    		}
    
    		public class Verse
    		{
    			public Verse(int verseNumber)
    			{
    				VerseNumber = verseNumber;
    				VerseLines = new List<string>();
    			}
    			public int VerseNumber { get; private set; }
    			public List<string> VerseLines { set; get; }
    		}
    	}
    
    }
