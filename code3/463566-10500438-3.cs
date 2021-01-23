    public class LinkCollection
    {
        Node peer;
        public LinkCollection(Node node) { peer = node; }
        void CheckIndex(int index) { if (index < 0 || index >= 10) throw new ArgumentOutOfRangeException(); }
        public Link default[int index] {
            get { CheckIndex(index); return peer.GetLink(index); }
            set { CheckIndex(index); peer.SetLink(index, value); }
        }
    }
    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public unsafe class Node
    {
        [FieldOffset(0)]
        public int LinkCount;
        [FieldOffset(4)]
        private fixed byte _linksData[10 * sizeof(Link)];
        unsafe Link GetLink(int index) { fixed( Link* plink = (Link*)&_linksData[0] ) return plink[index]; }
        unsafe void SetLink(int index, Link newvalue) { fixed( Link* plink = (Link*)&linksData[0] ) plink[index] = newvalue; }
        public LinkCollection Links { get { return new LinkCollection(this); } };
    }
