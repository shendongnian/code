        public static List<Control> FlattenChildren(this Control control)
        {
            var children = control.Controls.Cast<Control>();
            return children.SelectMany(c => FlattenChildren(c).Where(a => a is Label || a is Literal || a is Button || a is ImageButton || a is GridView || a is HyperLink || a is TabContainer || a is DropDownList || a is Panel)).Concat(children).ToList();
        }
        public static List<Control> GetAllControls(Control control)
        {
            var children = control.Controls.Cast<Control>();
            return children.SelectMany(c => FlattenChildren(c)).Concat(children).ToList();
        }
