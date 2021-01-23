        private void button_Click(object sender, EventArgs e)
        {
            using (DbEntities db = new DbEntities())
            {
               Articles firstArticle = db.Articles.FirstOrDefault(u => u.statusArticle == false);
               // firstArticle is not null anyways as you are calling FirstOrDefault()
                if (firstArticle != null)
                {
                    firstArticle.statusArticle = true;
                    db.SaveChanges();
                    MessageBox.Show("Article validated", "OK");
                    this.Refresh();
                }
            }
        }
