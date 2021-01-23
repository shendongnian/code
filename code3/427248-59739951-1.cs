     using System;
     using System.Collections;
     using System.Collections.Generic;
     using System.Linq;
     using System.Text.RegularExpressions;
     namespace algorithms
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                callAnnagrams();
                //callArrayChunkingStr();
                //callFizzBussStr();
                //callMaxChars();
                //callRevNumber();
                //string value = "Acheck";
                //Console.WriteLine("value" + value.IsStartWithA());
                //callPalindromeStringMethods();
                //callRevStringMethods();
    
            }
            public static void callRevStringMethods()
            {
                Console.WriteLine("Hello World!");
                string revString = RevStrings.RevString("You cannot convert an array of strings to an array of characters by just calling a method like ToCharArray");
                Console.WriteLine("reverse string " + revString);
    
                string revString2 = RevStrings.RevString2("You cannot convert an array of strings to an array of characters by just calling a method like ToCharArray");
                Console.WriteLine("reverse string2 " + revString2);
    
                string revString3 = RevStrings.RevString3("You cannot convert an array of strings to an array of characters by just calling a method like ToCharArray");
                Console.WriteLine("reverse string3 " + revString3);
    
                string revString4 = RevStrings.RevString4("You cannot convert an array of strings to an array of characters by just calling a method like ToCharArray");
                Console.WriteLine("reverse string4 " + revString4);
    
            }
            public static void callPalindromeStringMethods()
            {
                Console.WriteLine("Hello World!");
                bool blPalindrome = Palindrome.PalindromeString("abba");
                Console.WriteLine("string is Palindrome" + blPalindrome);
                bool blPalindrome1 = Palindrome.PalindromeString("dfasdf");
                Console.WriteLine("string is Palindrome" + blPalindrome1);
            }
    
            public static void callRevNumber()
            {
                
                Console.WriteLine("reversed -1123.567 value" + RevNumbers.RevNumber3(-1123.567));
                Console.WriteLine("reversed 1123.567 value" + RevNumbers.RevNumber3(1123.567));
                Console.WriteLine("reversed -1123.567" + RevNumbers.RevNumber2(-1123.567));
                Console.WriteLine("reversed 234 value" + RevNumbers.RevNumber(234));
                Console.WriteLine("reversed -234 value" + RevNumbers.RevNumber(-234));           
                
            }
    
            public static void callMaxChars()
            {
                //MaxChar.MaxCharsWithASCII("rwersfsdfsdfsdf");
                //MaxChar.MaxCharsWithASCII("testtestttettssssssssssstest");
                MaxChar.MaxCharsWithDictionary("testtestttettssssssssssstest");
                
            }
            public static void callFizzBussStr()
            {
                FizzBuss.FizzBussStr();
            }
            public static void callArrayChunkingStr()
            {
                int[] numArray = new int[] { 1, 3, 5, 6, 7, 8, 8,9 };
                ArrayList anum=new ArrayList { 'a','b','c','d','e' };
                ArrayChunking.ArrayChunkingStr2(anum, 3);
                Console.WriteLine();
                anum = new ArrayList { 1, 2, 3, 4, 5, 6, 7, 8,9 };
                ArrayChunking.ArrayChunkingStr2(anum, 2);
                Console.WriteLine();
                numArray = new int[] { 1, 2, 3, 4, 5 };
                ArrayChunking.ArrayChunkingStr(numArray, 10);
            }
            public static void callAnnagrams()
            {
                Annagram.Annagrams("this is a valid string ", "sa i hits daliv gnirts");
                Annagram.Annagrams("this is a valid string ", "ssdfasdfad dsfasdf453 $ ,fgdaliv gnirts");
                Annagram.Annagrams("string $ ONE ,", "snigtr # neo");
    
            }
        }
        public static class StringMethods
        {
            public static bool IsStartWithA(this string s)
            {
                return s.StartsWith('A');
            }
        }
        public class RevStrings
        {
            public static string RevString(string str)
            {
                var charArry = str.ToCharArray();
                Array.Reverse(charArry);
                return new string(charArry);
            }
            public static string RevString2(string str)
            {
                string revString = "";
                foreach( char c in str)
                {
                    revString = c + revString;
                }
                
                return revString;
            }
    
            //no change to the order of the words
            public static string RevString3(string str)
            {
                string[] strArray = str.Split(' ');
    
                string revString = "";
                foreach (string s in strArray)
                {
                    var charArray = s.ToCharArray();
                    Array.Reverse(charArray);
    
                    string reString = (strArray.Length > 1) ? new string(charArray) +" " : new string(charArray) + string.Empty;
                    revString +=  reString;
    
                }
    
                return revString;
            }
            public static string RevString4(string str)
            {
                string[] strArray = str.Split(' ');
    
                string revString = "";
                foreach (string s in strArray)
                {
                    string revWord = "";
                    foreach(char c in s)
                    {
                        revWord = c + revWord;
                    }
                    revString += revWord + " ";
                }
    
                return revString;
            }
    
        }
       
        public class Palindrome
        {
            public static bool PalindromeString(string str)
            {
                if (RevStrings.RevString3(str).ToUpper() == str.ToUpper())
                    return true;
                else
                    return false;
            }
        }
    
        public class RevNumbers
        {
            public static int RevNumber(int number)
            {
                string revStringNumber = RevStrings.RevString2(number.ToString().Replace("-", ""));
    
                Int32 num = Int32.Parse(revStringNumber) * Math.Sign(number);
                return num;
            }
            public static double RevNumber2(double number)
            {         
                string revStringNumber = RevStrings.RevString2(number.ToString().Replace("-", ""));
                double num = Convert.ToDouble(revStringNumber) * Math.Sign(number); 
    
                return num;
            }
            public static double RevNumber3(double number)
            {
                string[] strArray = number.ToString().Replace("-", "").Split('.');
                string revString = "";
                int i = 0;
    
                foreach (string s in strArray)
                {
                    var charArray = s.ToCharArray();
                    Array.Reverse(charArray);
                    string reString = new string(charArray);
                    if (i + 1 < strArray.Length && strArray[i].Length > 0)
                        revString += reString + ".";
                    else
                        revString += reString;
                    i++;
                }
                double num = Convert.ToDouble(revString.ToString().Replace("-", "")) * Math.Sign(number);
    
                return num;
    
    
            }
    
           
        }
    
        public class MaxChar
        {
            public static void MaxCharsWithASCII(string str)
            {
                int i = 0, l, max;
                int ascii;
                l = str.Length;
                int[] ch_freq = new int[255];
    
                for (i = 0; i < 255; i++)
                {
                    ch_freq[i] = 0;
                }
    
                i = 0;
                while(i<l)
                {
                    ascii = (int)str[i];
                    ch_freq[ascii] += 1;
    
                    i++;
                }
    
                max = 0;
                for(i=0; i<255; i++)
                {
                    if (i != 32)
                    {
                        if (ch_freq[i] > ch_freq[max])
                            max = i;
                    }
                }
                Console.Write("The Highest frequency of character '{0}' is appearing for number of times : {1} \n\n", (char)max, ch_freq[max]);
              
            }
            public static void MaxCharsWithDictionary(string str)
            {
                int i = 0, l, max;
                l = str.Length;
                Dictionary<int, int> char_freq = new Dictionary<int, int>();
    
                i = 0;
                while (i < l)
                {
                    if(!(char_freq.ContainsKey((int)str[i])))
                        char_freq.Add((int)str[i], 1);               
                    else
                        char_freq[(int)str[i]]= char_freq[str[i]]+1;
                    i++;
                }
    
                max = 0;
                for (i = 0; i < char_freq.Count; i++)
                {
                    
                        if (char_freq[str[i]] > char_freq[str[max]])
                            max = i;
                    
                }
                Console.Write("The Highest frequency of character '{0}' is appearing for number of times : {1} \n\n",(char)str[max], char_freq[str[max]]);
    
            }
            public static Dictionary<int,int> MaxCharsWithReturnDictionary(string str)
            {
                int i = 0, l, max;
                l = str.Length;
                Dictionary<int, int> char_freq = new Dictionary<int, int>();
    
                i = 0;
                while (i < l)
                {
                    if (!(char_freq.ContainsKey((int)str[i])))
                        char_freq.Add((int)str[i], 1);
                    else
                        char_freq[(int)str[i]] = char_freq[str[i]] + 1;
                    i++;
                }
    
                max = 0;
                for (i = 0; i < char_freq.Count; i++)
                {
    
                    if (char_freq[str[i]] > char_freq[str[max]])
                        max = i;
    
                }
                return char_freq;
            }
    
        }
    
        public class FizzBuss
        {
            public static void FizzBussStr()
            {
                double num =Convert.ToDouble(Console.ReadLine());
                for (int i = 1; i <= num; i++)
                {
                    if ((i % 3 == 0) && (i % 5 == 0)) //by both
                        Console.WriteLine("FizzBuzz");
                    else if (i % 3 == 0)  //by 3
                        Console.WriteLine("Fizz");
                    else if( i % 5 == 0) //by 5
                        Console.WriteLine("Buzz");
                    else Console.WriteLine(i);
                }
    
            }
        }
    
        public class ArrayChunking
        {
            public static ArrayList ArrayChunkingStr2(ArrayList intArray, int chunk)
            {
                ArrayList arrList = new ArrayList();
    
                int len = intArray.Count;
                int div = len / chunk;
                int howManyChunks = (len % chunk) > 0 ? div + 1 : div;
                int chkInc = 0;
                for (int chkk = 0; chkk < howManyChunks; chkk++)
                {
                    ArrayList arr = new ArrayList();
                    for (int i = 0; i < chunk; i++)
                    {
                        if ((i + chkInc) < len)
                        {
                            arr.Insert(i, intArray[i + chkInc]);
                        }
                    }
                    chkInc += chunk;
                    arrList.Add(arr);
                }
    
                if (howManyChunks > 0)
                {
                    //Console.Write("[");
                    string disarr = "[";
                    for (int j = 0; j < howManyChunks; j++)
                    {
                        //Console.Write("[");
                        disarr += "[";
    
                        ArrayList x = (ArrayList)arrList[j];
                        string dis = "";
                        for (int i = 0; i < x.Count; i++)
                        {
                            dis += x[i].ToString() + ",";
                        }
                        dis = dis.TrimEnd(',');
                        disarr += dis + "],";
                        //Console.Write(disarr);
                    }
                    disarr = disarr.TrimEnd(',');
                    //Console.Write("]");
                    disarr += "]";
                    Console.Write(disarr);
                }
                return arrList;
            }
            public static ArrayList ArrayChunkingStr(int[] intArray,int chunk)
            {
                ArrayList arrList = new ArrayList();
                
                int len = intArray.Length;
                int div = len / chunk;
                int howManyChunks = (len % chunk) > 0 ? div + 1: div;
                int chkInc = 0;
                for(int chkk=0; chkk < howManyChunks; chkk++)
                {
                    ArrayList arr = new ArrayList();
                    for (int i = 0; i < chunk; i++)
                    {
                        if ((i + chkInc) < len)
                        {
                            arr.Insert(i,intArray[i + chkInc]);
                        }
                    }
                    chkInc += chunk;
                    arrList.Add(arr);
                }
    
                if (howManyChunks > 0)
                {
                    //Console.Write("[");
                    string disarr = "[";
                    for (int j = 0; j < howManyChunks; j++)
                    {
                        //Console.Write("[");
                        disarr += "[";
    
                        ArrayList x = (ArrayList)arrList[j];
                        string dis = "";
                        for (int i = 0; i < x.Count; i++)
                        {
                            dis += x[i].ToString() + ",";
                        }
                        dis = dis.TrimEnd(',');
                        disarr += dis + "],";
                        //Console.Write(disarr);
                    }
                    disarr = disarr.TrimEnd(',');
                    //Console.Write("]");
                    disarr += "]";
                    Console.Write(disarr);
                }
                return arrList;
            }
        }
    
        public class Annagram
        {
            public static bool Annagrams(string str1, string str2)
            {
    
                str1 = Regex.Replace(str1.ToLower(), "[^a-zA-Z0-9]+", "", RegexOptions.Compiled);
                str2 = Regex.Replace(str2.ToLower(), "[^a-zA-Z0-9]+", "", RegexOptions.Compiled);
    
                Dictionary<int, int> str1Dic = MaxChar.MaxCharsWithReturnDictionary(str1.ToLower());
    
                Dictionary<int, int> str2Dic = MaxChar.MaxCharsWithReturnDictionary(str2.ToLower());
                if (str1Dic.Count != str2Dic.Count)
                {
                    Console.WriteLine("strings are not annagrams");
                    return false;
                }
                else
                {
                    if (!(str1Dic.Keys.All(str2Dic.ContainsKey)))
                    {
                        Console.WriteLine("strings are not annagrams");
                        return false;
                    }
                    else
                    {
                        var dict3 = str2Dic.Where(entry => str1Dic[entry.Key] != entry.Value)
                                .ToDictionary(entry => entry.Key, entry => entry.Value);
                        if (dict3.Count > 0)
                        {
                            Console.WriteLine("strings are not annagrams");
                            return false;
                        }
                        else
                        {
                            Console.WriteLine("strings are  annagrams");
                            return true;
                        }
                    }
    
    
                }
                
            }
        }
    }
