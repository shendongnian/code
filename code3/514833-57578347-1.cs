    using System.Linq;
    using System.Diagnostics;
    using System;
    using System.Text;
    using System.Globalization;
    
    //Created for 
    //http://metadataconsulting.blogspot.com/2019/03/A-Unicode-ReplaceAt-string-extension-method-handles-Unicode-string-properly.html
    
    public static class Program
    {
    
     
     const char cEMPTY = '\0'; 
        static readonly string EMPTY = cEMPTY.ToString(); 
     
        public static string UnicodeReplaceAt(this string str, int offset, char replaceChar)
        {
            int count = 1; //number of times to replace
            string replaceBy = replaceChar.ToString();
            return new StringInfo(str).ReplaceByPosition(replaceBy, offset, count).String;
        }
    
        public static StringInfo ReplaceByPosition(this StringInfo str, string replaceBy, int offset, int count)
        {
            if (replaceBy != EMPTY)
                return str.RemoveByTextElements(offset, count).InsertByTextElements(offset, replaceBy);
            else
                return str.RemoveByTextElements(offset, count);
        }
    
        public static StringInfo RemoveByTextElements(this StringInfo str, int offset, int count)
        { 
      //Tue 20-Aug-19 11:32am metadataconsulting.ca - replaceat index > string.len return orginal string
      if (offset > str.LengthInTextElements)
       return str;
      
            return new StringInfo(string.Concat(
                str.SubstringByTextElements(0, offset),
                offset + count < str.LengthInTextElements
                    ? str.SubstringByTextElements(offset + count, str.LengthInTextElements - count - offset)
                    : string.Empty
                ));
        }
        public static StringInfo InsertByTextElements(this StringInfo str, int offset, string insertStr)
        {
            //Tue 20-Aug-19 11:32am metadataconsulting.ca - replaceat index > string.len return orginal string
      if (offset > str.LengthInTextElements)
       return str;
      
      if (string.IsNullOrEmpty(str.String))
                return new StringInfo(insertStr);
    
            return new StringInfo(string.Concat(
                str.SubstringByTextElements(0, offset),
                insertStr,
                str.LengthInTextElements - offset > 0 ? str.SubstringByTextElements(offset, str.LengthInTextElements - offset) : ""
            ));
        }
    
        public static string SubsituteStringStringBuilder(this string s, int idx, char replaceChar)
        {
            if (string.IsNullOrEmpty(s) || idx >= s.Length || idx < 0)
                return s;
    
            return new StringBuilder(s).Remove(idx, 1).Insert(idx, replaceChar.ToString()).ToString();
        }
    
        public static string ReplaceAtSubstring(this string s, int idx, char replaceChar)
        {
            if (string.IsNullOrEmpty(s) || idx >= s.Length || idx < 0)
                return s;
    
            return s.Substring(0, idx) + replaceChar.ToString() + s.Substring(idx + replaceChar.ToString().Length, s.Length - (idx + replaceChar.ToString().Length));
    
        }
    
        public static string ReplaceAtStringManipulation(this string s, int idx, char replaceChar)
        {
            if (string.IsNullOrEmpty(s) || idx >= s.Length || idx < 0)
                return s;
    
            return s.Remove(idx, 1).Insert(idx, replaceChar.ToString());
        }
    
        public static string ReplaceAtLinq(this string value, int index, char newchar)
        {
            if (value.Length <= index)
                return value;
            else
                return string.Concat(value.Select((c, i) => i == index ? newchar : c));
        }
    
        public static string ReplaceAtCharArray(this string input, uint index, char newChar)
        {
            if (string.IsNullOrEmpty(input) || index >= input.Length)
                return input;
    
            char[] chars = input.ToCharArray();
            chars[index] = newChar;
            return new string(chars);
        }
    
        public static void Main()
        {
            //In .NET 4.5 and later also UTF-16 is supported
            //Console.OutputEncoding = System.Text.Encoding.Unicode;  
            
      //é  Latin Small Letter e with Acute U+00E9 - single byte Unicode character
      // Smiling Face with Smiling Eyes Emoji U+1F60A - double byte Unicode character
      // Multiple Musical Notes Emoji U+1F3B6 - - double byte Unicode character
      // Fire Emoji U+1F525 -- double byte Unicode character
      
      Console.WriteLine("Unicode String Replace At Issue");
      Console.WriteLine("Lets examine string \"é-\"");  
            Console.WriteLine("é- is length of " + "é-".Length + ", but there are ONLY 4 characters! Why not len=4?"); 
      Console.WriteLine(" are double byte UNICODE characters (> \\u10000) of width or len 2 each ");
      Console.WriteLine("é- below will replace space after lasting character '-' (position 4) with a sub using most common techniques seen online"); 
      
      Console.WriteLine(); 
      
      Stopwatch sw = new Stopwatch();
            sw.Start();
            Console.WriteLine("é- using ReplaceAtCharArray".ReplaceAtCharArray(4, 'X'));
            sw.Stop();
            Console.WriteLine("in {0} ticks.", sw.ElapsedTicks.ToString("N0"));
    
            sw.Restart();
            Console.WriteLine("é- using ReplaceAtLinq".ReplaceAtLinq(4, 'Y'));
            sw.Stop();
            Console.WriteLine("in {0} ticks.", sw.ElapsedTicks.ToString("N0"));
    
            sw.Restart();
            Console.WriteLine("é- using ReplaceAtStringManipulation".ReplaceAtStringManipulation(4, 'Z'));
            sw.Stop();
            Console.WriteLine("in {0} ticks.", sw.ElapsedTicks.ToString("N0"));
    
            sw.Restart();
            Console.WriteLine("é- using ReplaceAtSubstring".ReplaceAtSubstring(4, 'A'));
            sw.Stop();
            Console.WriteLine("in {0} ticks.", sw.ElapsedTicks.ToString("N0"));
    
            sw.Restart();
            Console.WriteLine("é- using SubsituteStringStringBuilder".SubsituteStringStringBuilder(4, 'W'));
            sw.Stop();
            Console.WriteLine("in {0} ticks.", sw.ElapsedTicks.ToString("N0"));
    
      sw.Restart();
            Console.WriteLine("é- using UnicodeReplaceAt".UnicodeReplaceAt(4, '4'));
            sw.Stop();
            Console.WriteLine("in {0} ticks.", sw.ElapsedTicks.ToString("N0"));
      
      Console.WriteLine(); 
      Console.WriteLine("UnicodeReplaceAt replaces properly at position 4 in zero based index string");
            Console.WriteLine(); 
      sw.Restart();
            Console.Write("é- using UnicodeReplaceAt(0, '0')".UnicodeReplaceAt(0, '0'));
            sw.Stop();
      Console.WriteLine(" in {0} ticks.", sw.ElapsedTicks.ToString("N0"));
      sw.Restart();
            Console.Write("é- using UnicodeReplaceAt(1, '1')".UnicodeReplaceAt(1, '1'));
            sw.Stop();
      Console.WriteLine(" in {0} ticks.", sw.ElapsedTicks.ToString("N0"));
      sw.Restart();
            Console.Write("é- using UnicodeReplaceAt(2, '2')".UnicodeReplaceAt(2, '2'));
            sw.Stop();
      Console.WriteLine(" in {0} ticks.", sw.ElapsedTicks.ToString("N0"));
      sw.Restart();
            Console.Write("é- using UnicodeReplaceAt(3, '3')".UnicodeReplaceAt(3, '3'));
            sw.Stop();
      Console.WriteLine(" in {0} ticks.", sw.ElapsedTicks.ToString("N0"));
      sw.Restart();
            Console.Write("é- using UnicodeReplaceAt(4, '4')".UnicodeReplaceAt(4, '4'));
            sw.Stop();
            Console.WriteLine(" in {0} ticks.", sw.ElapsedTicks.ToString("N0"));
         Console.Write("é-".UnicodeReplaceAt(5, '5')+" using UnicodeReplaceAt(5, '5') - this is beyond end of string, so return orginal string");
            sw.Stop();
            Console.WriteLine(" in {0} ticks.", sw.ElapsedTicks.ToString("N0"));
        
      
      
      Console.WriteLine(); 
      Console.WriteLine("String.Replace works, but replaces all characters, not at specific location as above functions");
            Console.WriteLine(); 
      Console.Write("é- using String.Replace".Replace("", "+") + "('', '+')");
    
      
        }
    }
