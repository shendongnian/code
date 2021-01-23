    public class AlphaNum : IComparable<AlphaNum> {
    
      private List<string> _alphas;
      private List<int> _nums;
    
      public AlphaNum(string value) {
        _alphas = new List<string>();
        _nums = new List<int>();
        bool alpha = true;
        int ofs = 0;
        for (int i = 0; i <= value.Length; i++) {
          if (i == value.Length || Char.IsDigit(value[i]) == alpha) {
            string s = value.Substring(ofs, i - ofs);
            if (alpha) {
              _alphas.Add(s);
            } else {
              _nums.Add(Int32.Parse(s));
            }
            ofs = i;
            alpha = !alpha;
          }
        }
      }
    
      public int CompareTo(AlphaNum other) {
        for (int i = 0;; i++) {
          bool e = i >= _alphas.Count;
          bool oe = i >= other._alphas.Count;
          if (e || oe) return e && oe ? 0 : e ? -1 : 1;
          int c = _alphas[i].CompareTo(other._alphas[i]);
          if (c != 0) return c;
          e = i >= _nums.Count;
          oe = i >= other._nums.Count;
          if (e || oe) return e && oe ? 0 : e ? -1 : 1;
          c = _nums[i].CompareTo(other._nums[i]);
          if (c != 0) return c;
        }
      }
    
    }
