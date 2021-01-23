     private void button_Click(object sender, EventArgs e)
            {
                using (DbEntities db = new DbEntities())
                {
                   Articles firstArticle = db.Articles.FirstOrDefault(u => u.statusArticle == false);
                    if (firstArticle != null)
                    {
                        firstArticle.statusArticle = true;
                        MessageBox.Show("Article validated", "OK");
                        db.SaveChanges(); //change
                        this.Refresh();
                    }
                }
            }
