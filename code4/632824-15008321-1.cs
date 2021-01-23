    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static void Main(string[] args) {
            var letters = args[0];
	        var wordList = new List<string> { "abcbca", "bca", "def" };
            var results = from string word in wordList
                          where IsValidAnswer(word, letters)
                          orderby word.Length descending
                          select word;
            foreach (var result in results) {
                Console.WriteLine(result);    
            }
        }
        private static bool IsValidAnswer(string word, string letters) {
            foreach (var letter in word) {
                if (letters.IndexOf(letter) == -1) {
                    return false;
                }
                letters = letters.Remove(letters.IndexOf(letter), 1);
            }
            return true;
        }
    }
