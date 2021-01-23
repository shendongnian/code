    public class ClearableForm : Form
    {
        public void ClearData()
        {
            Action<Control> traverseControls = null;
    
            traverseControls = (c) =>
                {
                    if (c is TextBox) ((TextBox)c).Text = string.Empty;
                    if (c is CheckBox) ((CheckBox)c).Checked = false;
                    if (c is DataGridView) ((DataGridView)c).DataSource = null;
                    c.Controls.Cast<Control>().ToList<Control>().ForEach(traverseControls);
                };
    
            traverseControls(this);
        }
    }
