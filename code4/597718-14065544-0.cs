    [HttpPost]
    public ActionResult Optimize(OptimizeModels model)
    {
        ObjOptimizeService = new OptimizeEventPerformance();
        if (ModelState.IsValid)
        {
            ObjOptimizeInputParameter.ObjectivetoOptimize = model.SelectedItem;
            model.ResponseXML = resultXMLContent;
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(resultXMLContent);
            xdoc.Save(Server.MapPath("..\\XML_Files\\OutputXML.xml"));
        }
        model.ChartName = ObjCommon.GetFusionSWFReportName("Optimization", "OEP_3");
        // if you intend to redisplay the same view you need to assign a value
        // for the Items property because your view relies on it (you have bound
        // a dropdownlist to it, remember?)
        model.Items = new[] 
        {
            new Item { Value = "Sales", Text = "Units" },
            new Item { Value = "RetGM", Text = "Rtlr Gross Margin ($)" },
            new Item { Value = "MfrGM", Text = "Mfr Gross Margin ($)" },
        };
        return View(model);
    }
