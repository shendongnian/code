    using YourClassLibraryNamespace;
    public class MyForm : Form
    {
        public void ShowGlassFormModal() {
            using (GlassForm form = new GlassForm()) {
                form.ShowDialog();
            }
        }
        public void ShowGlassForm() {
            new GlassForm().Show();
        }
    }
        
