    using System;
    using System.Web.UI;
    
    namespace StackOverFlow_2
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                {
                    double punctX = 10;
                    double punctY = 10;
    
                    double spacing = 5;
    
                    pnlImages.Style["position"] = "relative";
    
                    for (int y = 0; y < 3; y++)
                    {
                        System.Web.UI.WebControls.Image image = new System.Web.UI.WebControls.Image();
                        image.ID = "culoare" + y.ToString();
                        image.Style["position"] = "absolute";
                        image.Style["left"] = punctX.ToString() + "px";
                        image.Style["top"] = punctY.ToString() + "px";
                        image.Width = 100;
                        image.Height = 60;
                        image.ImageUrl = "~/Images/" + image.ID.ToString() + ".jpg";
                        
                        pnlImages.Controls.Add(image);                    
    
                        punctX += image.Width.Value + spacing;
    
                    }
                }
            }
        }
    }
