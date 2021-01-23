        private void button1_Click(object sender, System.EventArgs e)
        {
            using (var form = new Form1()) // you should dispose forms used as dialogs
            {
                if (DialogResult.OK == form.ShowDialog()) // optional (you could have OK/Cancel buttons etc
                {
                    Debug.WriteLine(form.SelectedValue ?? -1);
                }
            }
        }
