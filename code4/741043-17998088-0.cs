       public class SelectableLabel : Label
       {
          public SelectableLabel()
          {
             SetStyle(ControlStyles.Selectable, true);
             TabStop = true;
          }
    
          protected override void OnEnter(EventArgs e)
          {
             BackColor = Color.Red;
             base.OnEnter(e);
          }
    
          protected override void OnLeave(EventArgs e)
          {
             BackColor = SystemColors.Control;
             base.OnLeave(e);
          }
       }
