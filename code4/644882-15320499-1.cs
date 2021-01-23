       private void btnAddDymanicLabel_Click(object sender, EventArgs e)
        {
            Type type = GetTypeNameFromDomain("System.Windows.Forms.Label");
            Label lbl = (Label) Activator.CreateInstance(type);
            this.Controls.Add(lbl);
            lbl.Text = "dynamic created control";
        }
        private Type GetTypeNameFromDomain(string typename)
        {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes().Where(type => type.FullName == typename)).FirstOrDefault();
        }
