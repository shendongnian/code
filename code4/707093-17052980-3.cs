            if (System.Diagnostics.Debugger.IsAttached) {
                using (var debug = new Form2()) {
                    if (debug.ShowDialog() != DialogResult.OK) return;
                }
            }
            Application.Run(new Form1());
