    var locations = from r1 in 
              (from a in context.A
              join b in context.B
              on a.ID equals b.ID
              select new
              {
                a.Prop1,
                a.Prop2,
                b.Prop3,
                b.ID
              })
              join c in context.C
              on r1.ID equals c.ID
              select new
              {
                r1.Prop1,
                r2.Prop2,
                r2.Prop3,
                c.Prop4
              };
