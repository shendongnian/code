class Foo : Form {
     ToolTip tooltip = new ToolTip();
     public Foo(){
          tooltip.SetToolTip(this, "This is a tooltip!"); 
          foreach(Control ctrl in this.Controls) {
                tooltip.SetToolTip(ctrl, "This is a tooltip!");
            }
     }
}
