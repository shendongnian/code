    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;
    
    namespace templaten.com.Templaten
    {
        public class tRange
        {
            public int head, toe;
    
            public tRange(int _head, int _toe)
            {
                head = _head;
                toe = _toe;
            }
        }
    
        public enum AType
        {
            VALUE = 0,
            NAME = 1,
            OPEN = 2,
            CLOSE = 3,
            GROUP = 4
        }
    
        public class Atom
        {
            private AType kin;
            private string tag;
            private object data;
            private List<Atom> bag;
    
            public Atom(string _tag = "",
                        AType _kin = AType.VALUE,
                        object _data = null)
            {
                tag = _tag;
                if (String.IsNullOrEmpty(_tag))
                    _kin = AType.GROUP;
                kin = _kin;
    
                if (_kin == AType.GROUP)
                    bag = new List<Atom>();
                else
                    bag = null;
    
                data = _data;
            }
    
            public AType Kin
            {
                get { return kin; }
            }
    
            public string Tag
            {
                get { return tag; }
                set { tag = value; }
            }
    
            public List<Atom> Bag
            {
                get { return bag; }
            }
    
            public object Data
            {
                get { return data; }
                set { data = value; }
            }
    
            public int Add(string _tag = "",
                           AType _kin = AType.VALUE,
                           object _data = null)
            {
                if (bag != null)
                {
                    bag.Add(new Atom(_tag, _kin, _data));
                    return bag.Count - 1;
                }
                else
                {
                    return -1;
                }
            }
        }
    
        public class Templet
        {
            private string content;
    
            string namepat = "\\w+";
            string justName = "(\\w+)";
    
            string namePre = "@";
            string namePost = "";
    
            string comment0 = "\\<!--\\s*";
            string comment1 = "\\s*--\\>";
    
            private Atom tokens;                         // parsed contents
            private Dictionary<string, int> iNames;      // name index
            private Dictionary<string, tRange> iGroups;  // groups index
    
            private Atom buffer;                         // output buffer
            private Dictionary<string, int> _iname;      // output name index
            private Dictionary<string, tRange> _igroup;  // output index
    
            public Templet(string Content = null)
            {
                Init(Content);
            }
    
            private int[] mark(string[] names, string group)
            {
                if (names == null || names.Length < 1) return null;
                tRange t = new tRange(0, buffer.Bag.Count - 1);
                if (group != null)
                {
                    if (!_igroup.ContainsKey(group)) return null;
                    t = _igroup[group];
                }
    
                int[] marks = new int[names.Length];
    
                for (int i = 0; i < marks.Length; i++)
                    marks[i] = -1;
    
                for (int i = t.head; i <= t.toe; i++)
                {
                    if (buffer.Bag[i].Kin == AType.NAME)
                    {
                        for (int j = 0; j < names.Length; j++)
                        {
                            if (String.Compare(
                                names[j],
                                buffer.Bag[i].Tag,
                                true) == 0)
                            {
                                marks[j] = i;
                                break;
                            }
                        }
                    }
                }
                return marks;
            }
    
            public Filler Mark(string group, string names)
            {
                Filler f = new Filler(this, names);
                f.di = mark(f.names, group);
                f.Group = group;
                tRange t = null;
                if (_igroup.ContainsKey(group)) t = _igroup[group];
                f.Range = t;
                return f;
            }
    
            public Filler Mark(string names)
            {
                Filler f = new Filler(this, names);
    
                f.di = mark(f.names, null);
                f.Group = "";
                f.Range = null;
                return f;
            }
    
            public void Set(int[] locations, object[] x)
            {
                int j = Math.Min(x.Length, locations.Length);
                for (int i = 0; i < j; i++)
                {
                    int l = locations[i];
    
                    if ((l >= 0) && (buffer.Bag[l] != null))
                        buffer.Bag[l].Data = x[i];
                }
            }
    
            public void New(string group, int seq = 0)
            {
                // place new group copied from old group just below it
    
                if (!( iGroups.ContainsKey(group)
                    && _igroup.ContainsKey(group)
                    && seq > 0)) return;
    
                tRange newT = null;
                tRange t = iGroups[group];
                int beginRange = _igroup[group].toe + 1;
    
                for (int i = t.head; i <= t.toe; i++)
                {
                    buffer.Bag.Insert(beginRange,
                        new Atom(tokens.Bag[i].Tag,
                            tokens.Bag[i].Kin,
                            tokens.Bag[i].Data));
                    beginRange++;
                }
    
                newT = new tRange(t.toe + 1, t.toe + (t.toe - t.head + 1));
    
                // rename past group
                string pastGroup = group + "_" + seq;
                t = _igroup[group];
                buffer.Bag[t.head].Tag = pastGroup;
                buffer.Bag[t.toe].Tag = pastGroup;
    
                _igroup[pastGroup] = t;
    
                // change group indexes
                _igroup[group] = newT;
    
    
            }
    
            public void ReMark(Filler f, string group)
            {
                if (!_igroup.ContainsKey(group)) return;
                Map(buffer, _iname, _igroup);
                f.di = mark(f.names, group);
                f.Range = _igroup[group];
            }
    
            private static void Indexing(string aname,
                AType kin,
                int i,
                Dictionary<string, int> dd,
                Dictionary<string, tRange> gg)
            {
                switch (kin)
                {
                    case AType.NAME: // index all names
                        dd[aname] = i;
                        break;
                    case AType.OPEN: // index all groups
                        if (!gg.ContainsKey(aname))
                            gg[aname] = new tRange(i, -1);
                        else
                            gg[aname].head = i;
                        break;
                    case AType.CLOSE:
                        if (!gg.ContainsKey(aname))
                            gg[aname] = new tRange(-1, i);
                        else
                            gg[aname].toe = i;
                        break;
                    default:
                        break;
                }
            }
    
            private static void Map(Atom oo,
                Dictionary<string, int> dd,
                Dictionary<string, tRange> gg)
            {
    
                for (int i = 0; i < oo.Bag.Count; i++)
                {
                    string aname = oo.Bag[i].Tag;
                    Indexing(oo.Bag[i].Tag, oo.Bag[i].Kin, i, dd, gg);
                }
            }
    
            public void Init(string Content = null)
            {
                content = Content;
    
                tokens = new Atom("", AType.GROUP);
    
                iNames = new Dictionary<string, int>();
                iGroups = new Dictionary<string, tRange>();
    
                // parse content into tokens
                string namePattern = namePre + namepat + namePost;
                string patterns =
                    "(?<var>" + namePattern + ")|" +
                    "(?<head>" + comment0 + namePattern + ":" + comment1 + ")|" +
                    "(?<toe>" + comment0 + ":" + namePattern + comment1 + ")";
                Regex jn = new Regex(justName, RegexOptions.Compiled);
                Regex r = new Regex(patterns, RegexOptions.Compiled);
                MatchCollection ms = r.Matches(content);
                int pre = 0;
                foreach (Match m in ms)
                {
                    tokens.Add(content.Substring(pre, m.Index - pre));
                    int idx = -1;
                    if (m.Groups.Count >= 3)
                    {
                        string aname = "";
                        MatchCollection x = jn.Matches(m.Value);
                        if (x.Count > 0 && x[0].Groups.Count > 1)
                            aname = x[0].Groups[1].ToString();
                        AType t = AType.VALUE;
    
                        if (m.Groups[1].Length > 0) t = AType.NAME;
                        if (m.Groups[2].Length > 0) t = AType.OPEN;
                        if (m.Groups[3].Length > 0) t = AType.CLOSE;
                        if (aname.Length > 0)
                        {
                            tokens.Add(aname, t);
    
                            idx = tokens.Bag.Count - 1;
                        }
                        Indexing(aname, t, idx, iNames, iGroups);
                    }
                    pre = m.Index + m.Length;
                }
                if (pre < content.Length)
                    tokens.Add(content.Substring(pre, content.Length - pre));
    
                // copy tokens into buffer
                buffer = new Atom("", AType.GROUP);
                for (int i = 0; i < tokens.Bag.Count; i++)
                    buffer.Add(tokens.Bag[i].Tag, tokens.Bag[i].Kin);
    
                // initialize index of output names
                _iname = new Dictionary<string, int>();
                foreach (string k in iNames.Keys)
                    _iname[k] = iNames[k];
    
                // initialize index of output groups
                _igroup = new Dictionary<string, tRange>();
                foreach (string k in iGroups.Keys)
                {
                    tRange t = iGroups[k];
                    _igroup[k] = new tRange(t.head, t.toe);
                }
            }
    
            public string Get()
            {
                StringBuilder sb = new StringBuilder("");
                for (int i = 0; i < buffer.Bag.Count; i++)
                {
                    switch (buffer.Bag[i].Kin)
                    {
                        case AType.VALUE:
                            sb.Append(buffer.Bag[i].Tag);
                            break;
                        case AType.NAME:
                            sb.Append(buffer.Bag[i].Data);
                            break;
                        case AType.OPEN:
                        case AType.CLOSE:
                            break;
                        default: break;
                    }
                }
                return sb.ToString();
            }
    
    
        }
    
        public class Filler
        {
            private Templet t = null;
    
            public int[] di;
            public string[] names;
            public string Group { get; set; }
            public tRange Range { get; set; }
            private int seq = 0;
    
            public Filler(Templet tl, string markers = null)
            {
                t = tl;
                if (markers != null)
                    names = markers.Split(new char[] { ',' },
                        StringSplitOptions.RemoveEmptyEntries);
                else
                    names = null;
            }
    
            public void init(int length)
            {
                di = new int[length];
                for (int i = 0; i < length; i++)
                    di[i] = -1;
                seq = 0;
                Group = "";
                Range = null;
            }
    
            // clear contents inside marked object or group
            public void Clear()
            {
                object[] x = new object[di.Length];
                for (int i = 0; i < di.Length; i++)
                    x[i] = null;
                t.Set(di, x);
            }
    
            // set value for marked object,
            // or add row to group and set value to columns
            public void Set(params object[] x)
            {
                t.Set(di, x);
            }
    
            public void Add(params object[] x)
            {
                if (Group.Length > 0)
                {
                    t.New(Group, seq);
                    ++seq;
                    t.ReMark(this, Group);
                }
    
                t.Set(di, x);
            }
        }
    }
