    public ActionResult Index(int? AID_Artiest=810000)
    {
        ReadSelectie(AID_Artiest.Value);
    
        ViewBag.ID_Artiest = _ArtiestInfoModel.ID_Artiest;
        ViewBag.ArtiestenLijst = _ArtiestInfoModel.ArtiestenLijst;
    
        return View();
    }
    
    [HttpPost]
    public ActionResult Index(FormCollection ACollection)
    {
        int iID_Artiest;
        int.TryParse(ACollection["ID_Artiest"], out iID_Artiest);
        return Index(iID_Artiest);
    }
    
    public ActionResult Detail_Hitdossier(int? AID_Artiest)
    {
        int iID_Artiest = AID_Artiest ?? 810000;
    
        return View(GetArtiestData(iID_Artiest));
    }
