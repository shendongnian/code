    Gst.Application.Init();
    var pipeline = new Gst.Pipeline();
    var elementA = Gst.ElementFactory.Make("someElement");
    var elementB = Gst.ElementFactory.Make("someElement");
    pipeline.Add(elementA, elementB);
    elementA.Link(elementB);
    pipeline.SetState(Gst.State.Playing);
