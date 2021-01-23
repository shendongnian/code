        private void ShowDialogButton_Click(object sender, EventArgs e) {
            using (var dlg = new Form3()) {
                // Find the main form instance
                var main = Application.OpenForms.OfType<Form1>().Single();
                this.BeginInvoke(new Action(() => {
                    EnableWindow(main.Handle, true);
                }));
                if (dlg.ShowDialog(this) == DialogResult.OK) {
                    // etc..
                }
            }
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool EnableWindow(IntPtr handle, bool enable);
