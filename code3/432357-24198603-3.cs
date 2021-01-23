    <div>
        <h2>Some header above a graph</h2>
        <img src="@Url.Action("DrawChart",Model)" />
    </div>
    public ActionResult DrawChart(MyViewModel _MyViewModel )
    {
        MyViewModel model = MyViewModel ;
        return View(model);
    }
