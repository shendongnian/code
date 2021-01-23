    {
            
            frmFavorites.ShowIcon = false;
            frmFavorites.ShowInTaskbar = false;
            frmFavorites.MinimizeBox = false;
            frmFavorites.MaximizeBox = false;
            frmFavorites.ControlBox = false;
            frmFavorites.Text = "Bookmarks";
            frmFavorites.Width = 500;
            frmFavorites.Height = 350;
            frmFavorites.Controls.Add(lstFavorites);
            frmFavorites.Controls.Add(btnRemoveFavorite);
            frmFavorites.Controls.Add(btnAddFavorite);
            frmFavorites.Controls.Add(btnCloseFavorites);
            frmFavorites.Controls.Add(txtCurrentUrl);
            lstFavorites.Width = 484;
            lstFavorites.Height = 245;
            btnRemoveFavorite.Location = new Point(8, 280);
            btnAddFavorite.Location = new Point(8, 255);
            btnCloseFavorites.Location = new Point(400, 255);
            txtCurrentUrl.Location = new Point(110, 255);
            txtCurrentUrl.Size = new Size(255, 20);
            btnAddFavorite.Text = "Add";
            btnRemoveFavorite.Text = "Remove";
            btnCloseFavorites.Text = "Close";
            txtCurrentUrl.Text = wbBrowser.Url.ToString();
            btnAddFavorite.Click += new EventHandler(btnAddFavorite_Click);
            btnRemoveFavorite.Click += new EventHandler(btnRemoveFavorite_Click);
            frmFavorites.Load += new EventHandler(frmFavorites_Load);
            btnCloseFavorites.Click += new EventHandler(btnCloseFavorites_Click);
            lstFavorites.MouseDoubleClick += new MouseEventHandler(lstFavorites_MouseDoubleClick);
            frmFavorites.Show();
    }
    public void btnCloseFavorites_Click(object sender, EventArgs e)
    {
    if (lstFavorites.Items.Count > 0)
    {
    using (StreamWriter writer = new System.IO.StreamWriter(@Application.StartupPath + "\\favorites.txt"))
    {
    for (int i = 0; i < lstFavorites.Items.Count; i++)
    {
    writer.WriteLine(lstFavorites.Items[i].ToString());
    }
    writer.Close();
    }
    }
        frmFavorites.Hide();
    }
    public void btnAddFavorite_Click(object sender, EventArgs e)
        
        {
            string strFavoriteAddress = wbBrowser.Url.ToString();
            if (!lstFavorites.Items.Contains(strFavoriteAddress))
            {
                lstFavorites.Items.Add(strFavoriteAddress);
                MessageBox.Show("Favorite Added", "Message");
            }
            else if (lstFavorites.Items.Contains(strFavoriteAddress))
            {   
                MessageBox.Show("This site already exists in your Favorites list!", "Error");
            
            }
            else 
            {
            }
            
        }
        public void btnRemoveFavorite_Click(object sender, EventArgs e)
        {
            try
            {
                lstFavorites.Items.RemoveAt(lstFavorites.SelectedIndices[0]);
            }
            catch
            {
                MessageBox.Show("You need to select an item", "Error");
            }
        }
        public void frmFavorites_Load(object sender, EventArgs e)
        {
            try
            {
                using (StreamReader reader = new System.IO.StreamReader(@Application.StartupPath + "\\favorites.txt"))
                {
                    while (!reader.EndOfStream)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            string strListItem = reader.ReadLine();
                            if (!String.IsNullOrEmpty(strListItem))
                            {
                                lstFavorites.Items.Add(strListItem);
                            }
                        }
                    }
                    reader.Close();
                }
            }
            catch
            {
                MessageBox.Show("An error has occured", "Error");
            }
        }
        private void lstFavorites_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string strSelectedAddress = lstFavorites.Text.ToString();
            cmbAddress.Text = strSelectedAddress;
            wbBrowser.Navigate(strSelectedAddress);
            frmFavorites.Hide();
        }
