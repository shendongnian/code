    var allXvalues = queryResult.select(r=>r.CTB_MONTH).Distinct().OrderBy(month=>month).ToList();
    allXvalues
      .ForEach
       (
        xvalue=>
          {
            var p = approved.Where(o=>o.MONTH==xValue).FirstOrDefault();
            if(p==null)
                grafico.Series[0].Points.Add(new DataPoint(p.MONTH,p.AMT_C));
            else
                grafico.Series[0].Points.Add(new DataPoint(xvalue,0){IsEmpty=true});
          }
       );
