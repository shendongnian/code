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
    
            public void Add(string s) {
                if (s.Length > 255) throw new ArgumentOutOfRangeException("string too big.");
                this.strings.Add(s);
                this.dirty = true;
                for (byte i = 0; i < s.Length; i++) this.positions.Add(new StringPosition(strings.Count-1, i));
            }
    
            public void EnsureSorted() {
                if (dirty) {
                    this.positions.Sort(Compare);
                    this.dirty = false;
                }
            }
    
            public StringPosition BruteForce(string keyword) {
                for (int i = 0; i < this.strings.Count; i++) {
                    string s = this.strings[i];
                    int pos = s.IndexOf(keyword);
                    if (pos >= 0) return new StringPosition(i, (byte) pos);
                }
                return StringPosition.NotFound;
            }
    
            public StringPosition IndexOf(string keyword) {
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
                    return this.positions[minP];
                } else {
                    return StringPosition.NotFound;
                }
            }
    
            private int Compare(StringPosition pos1, StringPosition pos2) {
                int len = Math.Max(this.strings[pos1.ListIndex].Length - pos1.StringIndex, this.strings[pos2.ListIndex].Length - pos2.StringIndex);
                return String.Compare(strings[pos1.ListIndex], pos1.StringIndex, this.strings[pos2.ListIndex], pos2.StringIndex, len);
            }
    
            private int Compare(string keyword, StringPosition pos2) {
                return String.Compare(keyword, 0, this.strings[pos2.ListIndex], pos2.StringIndex, keyword.Length);
            }
    
            // Packs index of string, and position within string into a single int. This is
            // set up for strings no greater than 255 bytes. If longer strings are desired,
            // the code for the constructor, and extracting  ListIndex and StringIndex would
            // need to be modified accordingly.
            public struct StringPosition {
                public static StringPosition NotFound = new StringPosition(-1, 0);
                private readonly int position;
                public StringPosition(int listIndex, byte stringIndex) {
                    if (listIndex < 0) {
                        this.position = -1;
                    } else {
                        this.position = (listIndex << 8) | stringIndex;
                    }
                }
                public int ListIndex { get { return (this.position >= 0) ? (this.position >> 8) : -1; }
                }
                public byte StringIndex { get { return (byte) (this.position & 0xFF); } }
                public override string ToString() {
                    return ListIndex.ToString() + ":" + StringIndex;
                }
            }
        }
    }
