    public class Image
    {
        public SelectList ImageList { get; set; }
    
        public Image()
        {
            ImageList = GetImages();
        }
    
        public SelectList GetImages()
        {
            var list = new List<SelectListItem>();
            string connection = ConfigurationManager.ConnectionStrings["imageConnection"].ConnectionString;
    
            using (var con = new SqlConnection(connection))
            {
                con.Open();
                using (var command = new SqlCommand("SELECT * FROM Picture", con))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string title = reader[1] as string;
                        string imagePath = reader[2] as string;
                        list.Add(new SelectListItem() { Text = title, Value = imagePath });
                    }
                }
                con.Close();
            }
            return new SelectList(list,"Value","Text");
        }
    }
