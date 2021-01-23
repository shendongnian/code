    public partial class DlgGraphOptions : Form
    {
      public GraphOpts_t m_SerOpts { get; }
      public DlgGraphOptions(GraphOpts_t serOpts) {
        InitializeComponents();
        m_SerOpts = serOpts;
      }
    }
