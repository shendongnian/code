       class Program
       {
          static Dictionary<Char, String> DigitMap = new Dictionary<Char, String>()
          {
             {'0', "0"},
             {'1', "1"},
             {'2', "ABC"},
             {'3', "DEF"},
             {'4', "GHI"},
             {'5', "JKL"},
             {'6', "MNO"},
             {'7', "PQRS"},
             {'8', "TUV"},
             {'9', "WXYZ"}
          };
    
          static void Main(string[] args)
          {
             String phone = Regex.Replace("867-5309", "[^0-9]", "");
             recurse(phone, 0, new StringBuilder());
          }
    
          static void recurse(String phone, int index, StringBuilder sb)
          {
             // Terminating condition
             if (index == phone.Length)
             {
                Console.WriteLine(sb.ToString());
                return;
             }
    
             // Get digit and letters string
             Char digit = phone[index];
             String letters = DigitMap[digit];
    
             // Loop through all letter combinations for digit
             foreach (Char c in letters)
             {
                sb.Append(c);
                recurse(phone, index + 1, sb);
                sb.Length -= 1;
             }
          }
       }
    }
