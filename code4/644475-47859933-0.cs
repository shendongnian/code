    [Serializable()]
    public class SerializedClipboardFragment
    {
        readonly string[] m_ancestors;
        readonly string m_fragment;
        readonly int m_numberOfNodes;
        readonly bool m_isInsertingBlock;
        readonly bool m_isInsertingTable;
        public SerializedClipboardFragment(
            string[] ancestors,
            string fragment,
            int numberOfNodes,
            bool isInsertingBlock,
            bool isInsertingTable
            )
        {
            m_ancestors = ancestors;
            m_fragment = fragment;
            m_numberOfNodes = numberOfNodes;
            m_isInsertingBlock = isInsertingBlock;
            m_isInsertingTable = isInsertingTable;
        }
        internal static DataFormats.Format s_format;
        static SerializedClipboardFragment()
        {
            s_format = DataFormats.GetFormat(typeof(SerializedClipboardFragment).FullName);
        }
        ... etc -- various get-only properties ...
    }
