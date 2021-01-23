    using System.Reflection;
    private void openForm(string formName)
    {
        // First check if this form is authorized 
        if (GenelIslemler.formAuthCheck(formName))
        {
            // Then check if is already opened
            if (!IsOpen(formName))
            {
                // And now transform that string variable in the actual form to open
    
                // This is the critical line. You need the fully qualified form name. 
                // namespace + classname 
                Type formType = Type.GetType ("RapunzoApps.ThisApp." + formName);
                ConstructorInfo ctorInfo = formType.GetConstructor(Type.EmptyTypes);
                Form theForm = (Form) ctorInfo.Invoke (null);
                theForm.MdiParent = this;
                theForm.WindowState = FormWindowState.Maximized;
                theForm.Show();
            }
        }
        else
        {
            MessageBox.Show("You dont have rights to access!", "uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
