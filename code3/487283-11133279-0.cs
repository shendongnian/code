    var stopWatch=new StopWatch();
    stopWatch.Start();
    string html =string.empty;
            DataView dV = data.DefaultView;
            for(int i=0;i< dV.Count;i++)
            {
               html += dV.Row["X"].Tostring();
            } 
    stopWatch.Stop();
    Console.Write(stopWatch.EllapsedMilliseconds());
    var stopWatch=new StopWatch();
    stopWatch.Start();
    string html =new StringBuilder();
            DataView dV = data.DefaultView;
            for(int i=0;i< dV.Count;i++)
            {
               html.Append(dV.Row["X"].ToString());
            } 
    var finalHtml=html.ToString();
    stopWatch.Stop();
    Console.Write(stopWatch.EllapsedMilliseconds());
