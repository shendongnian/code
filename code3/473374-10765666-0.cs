    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace test
    {
        class Program
        {
            class IndexElement:IComparable<IndexElement>
            {
                public string value;
                public int x;
                public int y;
                public IndexElement(string v,int x,int y)
                {
                    this.value = v;
                    this.x = x;
                    this.y = y;
                }
    
                public int CompareTo(IndexElement other)
                {
                    return value.CompareTo(other.value);
                }
            }
    
            struct Position
            {
                public int x;
                public int y;
                public Position(int x, int y)
                {
                    this.x = x;
                    this.y = y;
                }
            }
            static void Main(string[] args)
            {
                string[,] symbols = new string[,] { { "if", "else" }, { "for", "foreach" }, { "while", "do" } };
                string[] text = new string[] { "for", "int", "in", "if", "then" };
                Dictionary<string, Position> dictionary = BuildDict(symbols);
                IndexElement[] index = BuildIndex(symbols);
                Console.WriteLine("Brute:");
                foreach (string s in CompareUsingBrute(text, symbols))
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine("Dict:");
                foreach (string s in CompareUsingIndex(text, dictionary))
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine("Indexing:");
                foreach (string s in CompareUsingDictionary(text, index))
                {
                    Console.WriteLine(s);
                }
                Console.ReadKey();
            }
    
            private static List<string> CompareUsingBrute(string[] text, string[,] symbols)
            {
                List<string> res = new List<string>();
                for (int x = 0; x < symbols.GetLength(0); x++)
                {
                    for (int y = 0; y < symbols.GetLength(1); y++)
                    {
                        for (int z = 0; z < text.Length; z++)
                        {
                            if (symbols[x, y] == text[z])
                                res.Add(text[z]);                        
                        }
                    }
                }
                return res;
    
            }
    
            private static List<string> CompareUsingDictionary(string[] text, IndexElement[] index)
            {
                List<string> res = new List<string>();
                foreach (string s in text)
                {
                    if (Array.BinarySearch<IndexElement>(index, new IndexElement(s, 0, 0)) >= 0)
                    {
                        res.Add(s);
                    }
                }
                return res;
            }
    
            private static IndexElement[] BuildIndex(string[,] symbols)
            {
                IndexElement[] res = new IndexElement[symbols.Length];
                int index = 0;
                for (int i = 0; i < symbols.GetLength(0); i++)
                {
                    for (int j = 0; j < symbols.GetLength(1); j++)
                    {
                        res[index] = new IndexElement(symbols[i, j], i, j);
                        index++;
                    }
                    
                }
                Array.Sort(res);
                return res;
            }
    
            private static List<string> CompareUsingIndex(string[] text, Dictionary<string, Position> dictionary)
            {
                List<string> res = new List<string>();
                foreach (string s in text)
                {
                    Position p;
                    if (dictionary.TryGetValue(s,out p))
                    {
                        res.Add(s);
                    }
                }
                return res;
            }
    
            private static Dictionary<string, Position> BuildDict(string[,] symbols)
            {
                Dictionary<string, Position> res = new Dictionary<string, Position>();
                for (int i = 0; i < symbols.GetLength(0); i++)
                {
                    for (int j = 0; j < symbols.GetLength(1); j++)
                    {
                        res.Add(symbols[i, j], new Position(i, j));
                    }
                }
                return res;
            }
    
            
        }
    }
