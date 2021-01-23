     private void Bindlist()
     {
    string id = Request.QueryString["ID"];
    List<MyImage> listImage=new List<MyImage>();
    using (SqlConnection connection = new SqlConnection(conString))
    {
        try
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("GetChildImages", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ChildID", id));
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        MyImage image=new MyImage();
                        image.ImageSRC=reader.GetString(0);
                        image.ThumbImageSRC=reader.GetString(1);
                        listImage.Add(image);
                    
                    }
                }
            }
        } 
        catch (Exception)
        {
            Response.Redirect("Error.htm", false);
        }
    }
    Repeater1.DataSource = listImage; 
    Repeater1.DataBind(); 
    }
    public class MyImage
    {
     public string ImageSRC { get; set; }
     public string ThumbImageSRC { get; set; }
    }
