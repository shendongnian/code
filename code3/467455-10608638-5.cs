    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;
    
    namespace ConsoleApplication1 {
        public class SearchStringList {
            private List<string> strings = new List<string>();
            private List<StringPosition> positions = new List<StringPosition>();
            private bool dirty = false;
            private readonly bool ignoreCase = true;
    
            public SearchStringList(bool ignoreCase) {
                this.ignoreCase = ignoreCase;
            }
    
            public void Add(string s) {
                if (s.Length > 255) throw new ArgumentOutOfRangeException("string too big.");
                this.strings.Add(s);
                this.dirty = true;
                for (byte i = 0; i < s.Length; i++) this.positions.Add(new StringPosition(strings.Count-1, i));
            }
    
            public string this[int index] { get { return this.strings[index]; } }
    
            public void EnsureSorted() {
                if (dirty) {
                    this.positions.Sort(Compare);
                    this.dirty = false;
                }
            }
    
            public IEnumerable<StringPosition> FindAll(string keyword) {
                var idx = IndexOf(keyword);
                while ((idx >= 0) && (idx < this.positions.Count)
                    && (Compare(keyword, this.positions[idx]) == 0)) {
                    yield return this.positions[idx];
                    idx++;
                }
            }
    
            private int IndexOf(string keyword) {
                EnsureSorted();
    
                // binary search
                // When the keyword appears multiple times, this should
                // point to the first match in positions. The following
                // positions could be examined for additional matches
                int minP = 0;
                int maxP = this.positions.Count - 1;
                while (maxP > minP) {
                    int midP = (minP + maxP) / 2;
                    if (Compare(keyword, this.positions[midP]) > 0) {
                        minP = midP + 1;
                    } else {
                        maxP = midP;
                    }
                }
                if ((maxP == minP) && (Compare(keyword, this.positions[minP]) == 0)) {
                    return minP;
                } else {
                    return -1;
                }
            }
    
            private int Compare(StringPosition pos1, StringPosition pos2) {
                int len = Math.Max(this.strings[pos1.ListIndex].Length - pos1.StringIndex, this.strings[pos2.ListIndex].Length - pos2.StringIndex);
                return String.Compare(strings[pos1.ListIndex], pos1.StringIndex, this.strings[pos2.ListIndex], pos2.StringIndex, len, ignoreCase);
            }
    
            private int Compare(string keyword, StringPosition pos2) {
                return String.Compare(keyword, 0, this.strings[pos2.ListIndex], pos2.StringIndex, keyword.Length, this.ignoreCase);
            }
    
            // Packs index of string, and position within string into a single int. This is
            // set up for strings no greater than 255 bytes. If longer strings are desired,
            // the code for the constructor, and extracting  ListIndex and StringIndex would
            // need to be modified accordingly, taking bits from ListIndex and using them
            // for StringIndex.
            public struct StringPosition {
                public static StringPosition NotFound = new StringPosition(-1, 0);
                private readonly int position;
                public StringPosition(int listIndex, byte stringIndex) {
                    this.position = (listIndex < 0) ? -1 : this.position = (listIndex << 8) | stringIndex;
                }
                public int ListIndex { get { return (this.position >= 0) ? (this.position >> 8) : -1; } }
                public byte StringIndex { get { return (byte) (this.position & 0xFF); } }
                public override string ToString() {
                    return ListIndex.ToString() + ":" + StringIndex;
                }
            }
        }
    }
    And to test it, you can use the following little console app
            static void Main(string[] args) {
                var list = new SearchStringList(true);
                list.Add("Now is the time");
                list.Add("for all good men");
                list.Add("Time now for something");
                list.Add("something completely different");
                while (true) {
                    string keyword = Console.ReadLine();
                    if (keyword.Length == 0) break;
                    foreach (var pos in list.FindAll(keyword)) {
                        Console.WriteLine(pos.ToString() + " =>" + list[pos.ListIndex]);
                    }
                }
            }
