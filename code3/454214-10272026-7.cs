            using (var session = factory.OpenSession())
            using(var tran = session.BeginTransaction())
            {
               var newPoint = session.Get<Point>(5);
               var newPoint2 = session.Get<Point>(2);
               var newLine = new Line { StartPoint = newPoint, EndPoint = newPoint2 };
                var foo2 = session.Get<Polygon>(1);
                foo2.Lines.Add(newLine);
                session.SaveOrUpdate(foo2);
                tran.Commit();
             }
