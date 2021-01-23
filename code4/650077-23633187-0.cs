    DataTable dt = new DataTable();
    dt.Columns.Add("Name", typeof(String));
    dt.Columns.Add("Image", typeof(Image));
    dt.Rows.Add("Img1", Properties.Resources.Img_1);
    dt.Rows.Add("Img2", Properties.Resources.Img_2);
    dt.Rows.Add("Img3", Properties.Resources.Img_3);
    dt.Rows.Add("Img4", Properties.Resources.Img_4);
    //// Loop Approach:
    //ImageList imgList = new ImageList();
    //for (int idx = 0; idx < dt.Rows.Count; idx++)
    //{
    //    imgList.Images.Add(dt.Rows[idx]["Image"] as Image);
    //}
    // LINQ Approach:
    ImageList imgList = new ImageList();
    imgList.Images.AddRange(dt.Rows.Cast<DataRow>().Select(row => row["Image"] as Image).ToArray());
