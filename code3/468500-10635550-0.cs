    public class BaseSelectionForm : Form
    {
        public string Selection { get; protected set; }
    }
    
    public class MainForm : Form
    {
        public List<string> Selections { get; set; }
    
        private void ButtonClick(object sender, EventArgs e)
        {
            using (var dialog = new CategoryForm())
            {
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Selections.Add(dialog.Item);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                }
            }
        }
    }
    
    public class CategoryForm : BaseSelectionForm 
    {
        private void ButtonClick(object sender, EventArgs e)
        {
            using (var dialog = new SubCategoryForm())
            {
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Selection = "This Category Name > " + dialog.Item;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                }
            }
        }
    }
    
    public class SubCategoryForm : BaseSelectionForm 
    {
        private void ButtonClick(object sender, EventArgs e)
        {
            Selection = "Brown Shirt / $34.00";
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
