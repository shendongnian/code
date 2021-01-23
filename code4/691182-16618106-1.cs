        protected void test_Click(object sender, EventArgs e)
        {
            string interests = "";
            for (int i = 0; i < ckblInterests.Items.Count; i++)
            {
                if (ckblInterests.Items[i].Selected)
                {
                    interests += ckblInterests.Items[i].Value + ", ";
                }
            }
            this.label.Text = interests;
        }
