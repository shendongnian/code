        protected void Page_Load(object sender, EventArgs e)
        {
            List<Image> images = new List<Image>
            {
                new Image("Picture 1","~/Images/Pic1.jpg"),
                new Image("Picture 2","~/Images/Pic2.jpg"),
            };
    
            gvImages.DataSource = images;
            gvImages.DataBind();
        }
    }
    
    public class Image
    {
        public Image(string name, string url)
        {
            this.name = name;
            this.url = url;
        }
    
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    
        private string url;
        public string URL
        {
            get { return url; }
            set { url = value; }
        }
    }
