      public partial class HomePage : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                    GetPictures();
            }
    
            private void ReDisplayPictures()
            {
                List<string> imagePaths = ViewState["Images"] as List<string>;
                if (imagePaths != null)
                {
                    foreach (string path in imagePaths)
                    {
                        var image = new Image
                        {
                            Width = 100,
                            Height = 100,
                            ImageUrl = path
                        };
                        pictures.Controls.Add(image);
                    }
                }
            }
    
            private void AddPicture(string imageUrl)
            {
                List<string> imagePaths = ViewState["Images"] as List<string>;
                if (imagePaths == null)
                {
                    imagePaths = new List<string>();
                }
                if (!imagePaths.Contains(imageUrl))
                {
                    imagePaths.Add(imageUrl);
                    ViewState["Images"] = imagePaths;
                }
            }
    
            protected void MovieChanged(object sender, EventArgs e)
            {
                AddPicture(ddlMovie.SelectedItem.Value);
                ReDisplayPictures();
            }
    
            private void GetPictures()
            {
                try
                {
                    string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    using (var conn = new SqlConnection(cs))
                    {
                        using (var command = new SqlCommand("SELECT * FROM Picture", conn))
                        {
                            conn.Open();
                            SqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                string name = reader["name"].ToString();
                                string path = reader["path"].ToString();
                                var item = new ListItem { Text = name, Value = path };
                                ddlMovie.Items.Add(item);
                            }
                        }
                        conn.Close();
                    }
                }
                catch (Exception eX)
                {
                    error.InnerHtml = String.Format("An error occured, description - {0}",
                        eX.Message);
                }
            }
        }
