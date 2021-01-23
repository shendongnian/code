    public static class FormValidator
    {
        public static bool IsValid<TForm>(TForm form) where TForm : Form {
            if (!string.IsNullOrEmpty(form.TextBox1.Text) && !string.IsNullOrEmpty(form.TextBox2.Text)) {
                return true;
            }
            else {
                return false;
            }
        }
    }
    // example:
    bool isValid = FormValidator.IsValid<MyForm>(myFormInstance);
