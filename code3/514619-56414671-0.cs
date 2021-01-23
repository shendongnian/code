       public ActionResult Index()
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"C:\proba\MvcApplication3\MvcApplication3\XMLFile1.xml");
                List<Class1> pitanja = new List<Class1>();
                Random rand = new Random();
                int broj1 = rand.Next(1, 3);
                int broj2 = rand.Next(3, 5);
                int broj3 = 5;
                TempData["odg1"] = broj1;
                TempData["odg2"] = broj2;
                TempData["odg3"] = broj3;
                string odg1 = Request.Form["odgg1"];
                string odg2 = Request.Form["odgg2"];
                string odg3 = Request.Form["odgg3"];
                TempData["korisodg1"] = odg1;
                TempData["korisodg2"] = odg2;
                TempData["korisodg3"] = odg3;
                foreach (XmlNode cvor in doc.SelectNodes("/kviz/Pitanje"))
                {
                    if (broj1.ToString() == cvor["Rbr"].InnerText)
                    {
                        pitanja.Add(
                            new Class1
                            {
                                pitanje = cvor["Pitanje"].InnerText,
                                odg1 = cvor["Odgovor1"].InnerText,
                                odg2 = cvor["Odgovor2"].InnerText,
                                odg3 = cvor["Odgovor3"].InnerText,
                                odg4 = cvor["Odgovor4"].InnerText,
                                resenje = cvor["Resenje"].InnerText
                            }
                            );
                    }
                    else if (broj2.ToString() == cvor["Rbr"].InnerText)
                    {
                        pitanja.Add(
                            new Class1
                            {
                                pitanje = cvor["Pitanje"].InnerText,
                                odg1 = cvor["Odgovor1"].InnerText,
                                odg2 = cvor["Odgovor2"].InnerText,
                                odg3 = cvor["Odgovor3"].InnerText,
                                odg4 = cvor["Odgovor4"].InnerText,
                                resenje = cvor["Resenje"].InnerText
                            }
                            );
                    }
                    else if (broj3.ToString() == cvor["Rbr"].InnerText)
                    {
                        pitanja.Add(
                            new Class1
                            {
                                pitanje = cvor["Pitanje"].InnerText,
                                odg1 = cvor["Odgovor1"].InnerText,
                                odg2 = cvor["Odgovor2"].InnerText,
                                odg3 = cvor["Odgovor3"].InnerText,
                                odg4 = cvor["Odgovor4"].InnerText,
                                resenje = cvor["Resenje"].InnerText
                            }
                            );
                    }
                }
                return View(pitanja);
            }
            public ActionResult operater()
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"C:\proba\MvcApplication3\MvcApplication3\XMLFile1.xml");
                List<Class1> pitanja = new List<Class1>();
                foreach (XmlNode cvor in doc.SelectNodes("/kviz/Pitanje"))
                {
                    if (TempData["odg1"].ToString() == cvor["Rbr"].InnerText)
                        pitanja.Add(new Class1
                        {
                            resenje = cvor["Resenje"].InnerText,
                            pitanje = cvor["Pitanje"].InnerText,
                            odgKorisnika = TempData["korisodg1"].ToString()
                        });
                    else if (TempData["odg2"].ToString() == cvor["Rbr"].InnerText)
                        pitanja.Add(new Class1
                        {
                            resenje = cvor["Resenje"].InnerText,
                            pitanje = cvor["Pitanje"].InnerText,
                            odgKorisnika = TempData["korisodg2"].ToString()
                        });
                    else if (TempData["odg3"].ToString() == cvor["Rbr"].InnerText)
                        pitanja.Add(new Class1
                        {
                            resenje = cvor["Resenje"].InnerText,
                            pitanje = cvor["Pitanje"].InnerText,
                            odgKorisnika = TempData["korisodg3"].ToString()
                        });
                }
                return View(pitanja);
            }
        }
    }
    @*@{
        ViewBag.Title = "Index";
        }
    @Html.ActionLink("Operater", "operater", "home")
    @Html.ActionLink("Nova pitanja","index","home")
    @using(Html.BeginForm("Index","home")){
        
    <h2>Index</h2>
        foreach (MvcApplication3.Models.Class1 pitanje in Model)
    {
        
        @pitanje.pitanje;
        <br />
        @pitanje.odg1;<br />
        @pitanje.odg2;<br />
        @pitanje.odg3;<br />
        @pitanje.odg4;<br />
        <hr />
    }
    <input type="text" name="odgg1"  /><br />
    <input type="text" name="odgg2" /><br />
    <input type="text" name="odgg3" /><br />
    <input type="submit" value ="Potvrdi" />
    }*@
    @*@{
        ViewBag.Title = "operater";
    }
    @Html.ActionLink("Nova pitanja","index","home")
    <h2>operater</h2>
    @foreach (MvcApplication3.Models.Class1 pitanj in Model)
    {
        @pitanj.pitanje;<br /> 
        @pitanj.resenje;<br /><br /><br />
        @pitanj.odgKorisnika;
        <hr />
    }*@
