      XmlDocument doc = new XmlDocument();
                doc.Load(@"F:\dji\A18rad\A18rad\XMLFile1.xml");
                List<vreme> vreme = new List<vreme>();
                string grad = Request.Form["grad"];
                foreach (XmlNode cvor in doc.SelectNodes("/vreme/Prognoza"))
                {
                    if (grad == cvor["NazivMesta"].InnerText)
                        vreme.Add(new vreme
                        {
                            mesto = cvor["NazivMesta"].InnerText,
                            maxtemp = cvor["MaxTemperatura"].InnerText,
                            mintemp = cvor["MinTemperatura"].InnerText,
                            vremee = cvor["Vreme"].InnerText
                        });
                }
                return View(vreme);
            }
            public ActionResult maxtemperature()
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"F:\dji\A18rad\A18rad\XMLFile1.xml");
                List<vreme> vreme = new List<vreme>();
                foreach (XmlNode cvor in doc.SelectNodes("/vreme/Prognoza"))
                {
                    vreme.Add(new vreme
                    {
                        mesto = cvor["NazivMesta"].InnerText,
                        maxtemp = cvor["MaxTemperatura"].InnerText
                    });
                }
                return View(vreme);
            }
        }
    }
    @*@{
        ViewBag.Title = "maxtemperature";
    }
    @Html.ActionLink("Vreme Po izboru","index","home")
    <h2>maxtemperature</h2>
    <table border="10">
        <tr><th>Mesto</th>
            <th>MaxTemp</th>
        </tr>
    @foreach (A18rad.Models.vreme vr in Model)
    {
        <tr>
            <td>@vr.mesto</td>
            <td>@vr.maxtemp</td>
        </tr>
    }
        </table>*@
    @*@{
        ViewBag.Title = "Index";
    }
    @Html.ActionLink("MaxTemperature","maxtemperature","home")
    @using(Html.BeginForm("Index","Home")){
    <h2>Index</h2>
        <span>Grad:</span><select name="grad">
            <option  value="Nis">Nis</option>
            <option value="Beograd">Beograd</option>
            <option value="Kopaonik">Kopaonik</option>
        </select>
        <input type="submit" value="Moze" /><br />
        foreach (A18rad.Models.vreme vr in Model)
        {
         <span>Min temperatura:</span>  @vr.mintemp<br />
           <span>Max temperatura:</span> @vr.maxtemp<br />
            if(vr.vremee =="Kisa"){
          <span>Vreme:</span>  <img src ="kisa.jpg" />
            }
            else if(vr.vremee =="Sneg"){
               <img src="sneg.jpg" />
           } else if (vr.vremee == "Vedro") { 
           
            <img src ="vedro.png" /><br />
           }
    }
        
       
            
            
    }*@
