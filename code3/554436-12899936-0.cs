        private void ChangeLanguage(string lang) {
            var ci = new CultureInfo(lang);
            System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
            foreach (Control c in this.Controls) {
                ComponentResourceManager resources = new ComponentResourceManager(this.GetType());
                resources.ApplyResources(c, c.Name, ci);
                if (c.GetType() == typeof(DataGridView)) {
                    var dgv = (DataGridView)c;
                    foreach (DataGridViewColumn col in dgv.Columns) {
                        resources.ApplyResources(col, col.Name);
                    }
                }
            }
        }
