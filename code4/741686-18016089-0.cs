    DtTest
    .GroupBy
    (
       x=>
       new
       {
           BNO = x.Field<int>("BNO"),
           INO = x.Field<int>("INO"),
           Desp = x.Field<string>("Desp"),
           Rate= x.Field<int>("Rate")
       }
    )
    .Select
    (
       x=>
       new 
       {
          x.Key.BNO,
          x.Key.INO,
          x.Key.Desp,
          Qty = x.Sum(z=>z.Field<int>("Qty"))
          x.Key.Rate,
          Amount = x.Sum(z=>z.Field<int>("Amount"))
       }
    );
