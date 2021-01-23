public class Node
{
    private string mStr;
    private string mOperation;
    private List<Node> mChildren = new List<Node>();
    //private Collection mCollection = new Collection();
    public Node(string input)
    {
        mStr = Regex.Replace(input, @"^\(([^\(\)]*)\)$", "$1");
        Init();
    }
    private void Init()
    {
        Split(mStr);
        return;
    }
    public Collection GenerateHands()
    {
        Collection collection = new Collection();
        if (Children == 0) { collection.Add(mStr); }
        if (Children > 0)
        {
            if (mOperation == "union") { collection = mChildren.ElementAt(0).GenerateHands().Union(mChildren.ElementAt(1).GenerateHands()); }
            if (mOperation == "intersect") { collection = mChildren.ElementAt(0).GenerateHands().Intersect(mChildren.ElementAt(1).GenerateHands()); }
            if (mOperation == "less") { collection = mChildren.ElementAt(0).GenerateHands().Less(mChildren.ElementAt(1).GenerateHands()); }
        }
        return collection;
    }
    public string PrettyPrint()
    {
        string print = "";
        if (Children == 0) { print += mStr; }
        if (Children > 0)
        {
            if (mChildren.ElementAt(0).Children > 0) { print += "("; }
            print += mChildren.ElementAt(0).PrettyPrint();
            if (mChildren.ElementAt(0).Children > 0) { print += ")"; }
            if (Children > 0) { print += " " + mOperation + " "; }
            if (mChildren.ElementAt(1).Children > 0) { print += "("; }
            print += mChildren.ElementAt(1).PrettyPrint();
            if (mChildren.ElementAt(1).Children > 0) { print += ")"; }
        }
        return print;
    }
    private void Split(string s)
    {
        // WARNING: Either could pass a,aa or a:aa
        // WARNING: This can hand down a 0 length string if ',' is at beginning or end of s.
        if (CommaOutsideBrackets(s) >= 0)
        {
            mChildren.Add(new Node(s.Substring(0, CommaOutsideBrackets(s))));
            mChildren.Add(new Node(s.Substring(CommaOutsideBrackets(s) + 1, s.Count() - CommaOutsideBrackets(s) - 1)));
            mOperation = "union";
        }
        // WARNING: This could throw negative if for example (aaaa)bb
        else if (OperatorOutsideBrackets(s) >= 0)
        {
            mChildren.Add(new Node(s.Substring(0, OperatorOutsideBrackets(s))));
            mChildren.Add(new Node(s.Substring(OperatorOutsideBrackets(s) + 1, s.Count() - OperatorOutsideBrackets(s) - 1)));
            if (s[OperatorOutsideBrackets(s)] == '!') { mOperation = "less"; }
            if (s[OperatorOutsideBrackets(s)] == ':') { mOperation = "intersection"; }
        }
        // We must be done?
        else
        {
        }
    }
    private int CommaOutsideBrackets(string s)
    {
        int countRound = 0, countSquare = 0;
        for (int i = 0; i < s.Count(); i++)
        {
            if (s[i] == '(') { countRound += 1; }
            if (s[i] == ')') { countRound -= 1; }
            if (s[i] == '[') { countSquare += 1; }
            if (s[i] == ']') { countSquare -= 1; }
            if (s[i] == ',' && countRound == 0 && countSquare == 0) { return i; }
        }
        return -1;
    }
    private int OperatorOutsideBrackets(string s)
    {
        for (int i = s.Count() - 1; i >= 0; i--)
        {
            if (s[i] == '!' || s[i] == ':') { return i; }
        }
        return -1;
    }
    public string Str
    {
        get { return mStr; }
    }
    public int Children
    {
        get { return mChildren.Count; }
    }
}
