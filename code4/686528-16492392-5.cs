    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace StackOverflow16491866 {
    	class Program {
    		static void Main(string[] args) {
    			string Notes = "Some nine word note which I'm stretching here now";
    			List<string> Words = Notes.Split(' ').ToList();
    			int WordsPerLine = (int)Words.Count/3;
    			string Note1 = string.Join(" ", Words.GetRange(0, WordsPerLine));
    			string Note2 = string.Join(" ", Words.GetRange(WordsPerLine, WordsPerLine));
    			string Note3 = string.Join(" ", Words.GetRange(WordsPerLine * 2, Words.Count - WordsPerLine * 2 - 1));
    			Console.WriteLine("{0}\n{1}\n{2}", Note1, Note2, Note3);
    			Console.ReadLine();
    		}
    	}
    }
