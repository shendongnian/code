    var myList = xDoc.Descendants("localita").Select(n => {
       var previsione = n.Descendants("previsione").First();
    
       return new {
          ID = n.Element("id").Value.ToString(),
          ....
          MeteoOggi = new MeteoGiorno()
          {
              Min = previsione.Element("temp_perc").Value.ToString(),
              Max = previsione.Element("temp").Value.ToString(),
              ....
          }
       }
    });
