    public class UniversalFormTranslater
    {
        public void TranslateForm(System.Windows.Forms.ContainerControl container)
        {
            var name = container.Name;
            var originalText = container.Text;
            if (!string.IsNullOrEmpty(originalText))
                container.Text = Translate(name);
                
            TranslateControl(container);
        }
    
        private void TranslateControl(string parentName, System.Windows.Forms.ContainerControl control)
        {
            var name = parentName + "." + control.Name;
            var originalText = control.Text;
            if (!string.IsNullOrEmpty(originalText))
                control.Text = Translate(name);
        }
    
        private void TranslateControl(string parentName, System.Windows.Forms.ContainerControl container)
        {
            var name = parentName + "." + container.Name;
            var originalText = container.Text;
            if (!string.IsNullOrEmpty(originalText))
                container.Text = Translate(name);
            
            foreach (var control in container.Controls)
            {
                TranslateControl(control);
            }
        }
    
        public void Translate(string controlName)
        {
            // return the translation.
        }
    }
