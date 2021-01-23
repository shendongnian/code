    public void BuildList()
    {
        DataTable variants = Common.GetAllVariantsFromDB(modelCode);
        variantsList.InnerHtml += "<span id=\"variant\">" + Common.GetVariantInfo(variant)[0] + "</span>";
        variantsList.InnerHtml += "<ul id=\"variantsList\">";
        for (int i = 0; i < variants.Rows.Count; i++)
        {
            if (variants.Rows[i]["Variant"].ToString() != "GJ1")
            {
                variantsList.InnerHtml += "<li><a href=\"#" + variants.Rows[i]["Variant"].ToString() + "\">" + variants.Rows[i]["EngineSize"].ToString()</a></li>";
            }
        }
        variantsList.InnerHtml += "</ul>";
    }
