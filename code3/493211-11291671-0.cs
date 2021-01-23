            foreach (var k in res1)
            {
                var eigen = from p in aspnetdb.Trackpoints
                            where p.RouteFK == k
                            select p;
                var item = eigen.FirstOrDefault();
                if ( item != null )
                {
                  aspnetdb.Trackpoints.DeleteOnSubmit(item);
                  aspnetdb.SubmitChanges();
                }
            }
