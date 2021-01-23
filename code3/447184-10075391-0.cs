    public class ButtonGroup {
       private IList<RadioButton> radiogroup;
    
       public ButtonGroup(IEnumerable<RadioButton> selection) {
          radiogroup = new List<RadioButton>(selection);
          foreach (RadioButton item in selection) {
              item.CheckedChanged += uncheckOthers;
          }
       }
    
       private void uncheckOthers(object sender, EventArgs e) {
          if (((RadioButton)sender).Checked)) {
            foreach (RadioButton item in radiogroup) {
              if (item != sender) { item.Checked = false; }
            }
          }
       }
    }
