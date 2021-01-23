    // sample code
    var layout1 = Resolve(1);
    session.Attach(layout1);  // now contains layout 1
    var layout2 = Resolve(1);
    session.Attach(layout2);  // error: already contains layout with id 1
    public Layout Resolve(int id)
    {
        using (var session = OpenSession())
        {
            return GetNewSession.Get<Layout>(1);
        }
    }
