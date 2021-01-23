    [HttpPost]
    public ActionResult Analyser(FormCollection collection)
    {
        IList<float> sfr = new List<float>();
        for (int i = 0; i < Global.seg.Count; i++)
        {
            if (collection.AllKeys.Contains(i.ToString())) 
            {
                foreach (Point e in Global.seg[i]._pointsListe)
                {
                    sfr.Add(e._latitude);
                    sfr.Add(e._longitude);
                }
            }
        }
        var rvd = new RouteValueDictionary();
        for (int i = 0; i < sfr.Count; i++)
        {
            rvd[string.Format("sf[{0}]", i)] = sfr[i];
        }
        if (sfr.Count == 4) return RedirectToAction("_two", rvd);
        if (sfr.Count == 6) return RedirectToAction("_two", rvd);
        if (sfr.Count == 8) return RedirectToAction("_four", rvd);
        if (sfr.Count == 10) return RedirectToAction("_five", rvd);
        if (sfr.Count == 12) return RedirectToAction("_six", rvd);
        else return RedirectToAction("_others", rvd);
    }
