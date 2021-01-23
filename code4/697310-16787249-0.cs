    public JsonResult PosteExists(string poste)
    {
        var exists = db.Postes.Any(x => x.ID_Poste == poste.Trim())
        return !exists ?
            Json(true, JsonRequestBehavior.AllowGet) :
            Json(string.Format("{0} is not available.", poste),
            JsonRequestBehavior.AllowGet);
    }
