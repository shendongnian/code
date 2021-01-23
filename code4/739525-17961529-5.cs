    // your existing code:
    List<string> list = new List<string>();
                list.Add("p1.jpg");
                list.Add("p2.jpg");
                list.Add("p3.jpg");
    // to xml:
    var xPhotos = new XElement("Photos");
    foreach(string x in list)
    	xPhotos.Add(new XElement("Photo", x));
    var xdoc = new XDocument(xPhotos);
