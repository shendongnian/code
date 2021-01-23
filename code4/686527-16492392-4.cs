    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace StackOverflow16491866 {
    	class Program {
    		static void Main(string[] args) {
    			string notes = "Some nine word note which I'm stretching here now ";
    			List<string> words = new List<string>();
    			string word = "";
    			int idx = 0;
    			while (idx < notes.Length) {
    				word += notes[idx];
    				if (notes[idx] == ' ') {
    					words.Add(word);
    					word = "";
    				}
    				++idx;
    			}
    			string notes1 = "";
    			string notes2 = "";
    			string notes3 = "";
    
    			int one_third = words.Count / 3;
    			int two_thirds = (words.Count / 3) * 2;
    
    			int k;
    			for (k = 0; k < one_third; k++)
    				notes1 += words.ElementAt(k) + ' ';
    			for (k = one_third; k < two_thirds; k++)
    				notes2 += words[k] + ' ';
    			for (k = two_thirds; k < words.Count; k++)
    				notes3 += words[k] + ' ';
    
    			Console.WriteLine(notes1);
    			Console.WriteLine(notes2);
    			Console.WriteLine(notes3);
    			Console.ReadLine();
    
    		}
    	}
    }
