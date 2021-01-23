      //Method for replacing chars with a mapping
      static string Replace(string input, IDictionary<char, char> replacementMap) {
          return replacementMap.Keys
              .Aggregate(input, (current, oldChar) 
                  => current.Replace(oldChar, replacementMap[oldChar]));
      }
      private static void Main(string[] args) {
          //Char to char map using <oldChar, newChar>
          var charMap = new Dictionary<char, char>();
          charMap.Add('-', 'D'); charMap.Add('|', 'P'); charMap.Add('@', 'A');
          //Your input string
          string myString = "asgjk--@dfsg||jshd--f@jgsld-kj|rhgunfh-@-nsdflngs";
          //Your own replacement method
          myString = Replace(myString, charMap);
          //out: myString = "asgjkDDAdfsgPPjshdDDfAjgsldDkjPrhgunfhDADnsdflngs"
      }
