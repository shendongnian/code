     public class AgeInfo
            {
    
                public string age;
                public int population;
                
                public AgeInfo(string prmAge, int prmPop)
                {
                    this.age = prmAge;
                    this.population = prmPop;
                }
    
            }
    
    
            // http://gunnarpeipman.com/2017/10/aspnet-core-node-d3js/
            public async Task<IActionResult> Chart([FromServices] INodeServices nodeServices)
            {
                var options = new { width = 400, height = 200 };
                
                var data = new[] {
                    new { label = "Abulia", count = 10 },
                    new { label = "Betelgeuse", count = 20 },
                    new { label = "Cantaloupe", count = 30 },
                    new { label = "Dijkstra", count = 40 }
                };
                
                List<AgeInfo> ls = new List<AgeInfo>();
                ls.Add( new AgeInfo("<5", 2704659));
                ls.Add( new AgeInfo("5-13", 4499890));
                ls.Add( new AgeInfo("14-17", 2159981));
                ls.Add( new AgeInfo("18-24", 3853788));
                ls.Add( new AgeInfo("25-44", 14106543));
                ls.Add( new AgeInfo("45-64", 8819342));
                ls.Add( new AgeInfo("≥65", 612463));
                
                
                // string markup = await nodeServices.InvokeAsync<string>("Node/d3Pie.js", options, data);
                
                string markup = await nodeServices.InvokeAsync<string>("Node/d3chart.js", options, ls);
                
                string html = @"<!DOCTYPE html>
    <html>
    <head><meta charset=""utf-8"" />
    <style type=""text/css"">
    .arc text 
    {
      font: 10px sans-serif;
      text-anchor: middle;
    }
    .arc path 
    {
      stroke: #fff;
    }
    </style>
    </head>
    <body>
        <img src=""" + markup + @""" />
    </body>
    </html>";
                
                return Content(html, "text/html");
            }
