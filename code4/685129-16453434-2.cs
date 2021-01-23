    public class ToolBox : ToolBoxBase
    {
       public CustomLabel
       {
          get
          {
             return label1.Text;
          }
          set
          {
             label1.Text = value;
          }
       }
    }
    private ToolBox toolbox;
    void ShowToolBox()
    {
       InitToolBox();
       toolbox.CustomLabel = "New label";
    }
