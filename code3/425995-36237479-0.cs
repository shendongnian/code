    List<MvcApplication1.Models.Country> cntry = db.Countries.ToList();
    SelectListItem sss = new SelectListItem();
    List<SelectListItem> sltst = new List<SelectListItem>();
    sss.Text = "Select";
    sss.Value = "0";
    sltst.Add(sss);
    foreach (MvcApplication1.Models.Country s in cntry){
    SelectListItem s1 = new SelectListItem();
    s1.Text = s.Country1;
    s1.Value = Convert.ToString(s.Id);
    sltst.Add(s1);}
    @Html.DropDownList("country", sltst, new { @id = "country" })
