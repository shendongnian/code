    public ActionResult Test()
    {
        ChartModel<int, int> model = new ChartModel<int, int>();
        model.Data = new List<Pair<int, int>>();
        for (int i = 0; i < 10; i++)
        {
            Pair<int, int> p = new Pair<int, int>();
            p.X = i;
            p.Y = i;
            model.Data.Add(p);
        }
        return View(model);
    }
