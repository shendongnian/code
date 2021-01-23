    using System;
    using System.Collections.Generic;
    using System.IO;
    class Tree
    {
        int currentIndent;
        public Tree(string s)
        {
            this.Trees = new List<Tree>();
            this.Values = new List<string>();
            this.currentIndent = 0;
            if (s == null)
                throw new ArgumentNullException();
            if (s == "")
                return;
            int beginPos = 0;
            while (beginPos < s.Length)
            {
                if (s[beginPos] == '[')
                {
                    string res = "";
                    uint openedBraceCount = 1;
                    uint closedBraceCount = 0;
                    int index = beginPos + 1;
                    while (openedBraceCount != closedBraceCount)
                    {
                        if (s[index] == '[')
                            openedBraceCount++;
                        if (s[index] == ']')
                            closedBraceCount++;
                        res += s[index];
                        index++;
                    }
                    beginPos = index;
                    this.Trees.Add(new Tree(res.Substring(0, res.Length - 1)));
                }
                else
                {
                    int endPos = beginPos + 1;
                    while (endPos < s.Length && s[endPos] != '[')
                        endPos++;
                    string[] values = s.Substring(beginPos, endPos - beginPos).Split('|');
                    for (int i = 0; i < values.Length; i++)
                        values[i] = values[i].Trim();
                    this.Values.AddRange(values);
                    beginPos = endPos;
                }
            }
        }
        public void Print(TextWriter writer, int indent)
        {
            this.currentIndent = indent;
            Print(writer, 0, this);
            this.currentIndent = 0;
        }
        private void Print(TextWriter writer, int indent, Tree tree)
        {
            foreach (string value in tree.Values)
                writer.WriteLine("{0}{1}", new string(' ', indent), value);
            foreach (Tree t in tree.Trees)
                Print(writer, currentIndent + indent, t);
        }
        public List<Tree> Trees { get; set; }
        public List<string> Values { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string s = "[[Le[[filet|tartare]]|La grillade]]de gateau|Une [[portion|part]] de gateau";
            var tree = new Tree(s);
            tree.Print(Console.Out, 2);
        }
    }
