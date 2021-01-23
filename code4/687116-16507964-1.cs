        private void button_Click(object sender, EventArgs e)
        {
            using (DbEntities db = new DbEntities())
            {
               Articles firstArticle = db.Articles.FirstOrDefault(u => u.statusArticle == false);
               // firstArticle is not null anyways as you are calling FirstOrDefault()
             **EDIT** // In case nothing has status = false, you will get a new Articles object, so instead of the below null check, you have to check for other property like id or name that will be unique.
                if (firstArticle != null)
                {
                    firstArticle.statusArticle = true;
                    db.SaveChanges();
                    MessageBox.Show("Article validated", "OK");
                    this.Refresh();
                }
            }
        }
