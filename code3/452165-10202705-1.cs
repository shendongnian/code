    var query = from consumer in Tb_Consumer.AsEnumerable()
                join transaction in Tb_Transactions.AsEnumerable()
                on consumer.Field<string>("Con_id") equals transaction.Field<string>("Con_id")
                group consumer by new { city = consumer.Field<string>("City_name") } into g
                select new
                {
                      CityName = g.Key,
                      Sales = g.Sum(a => a.Field<decimal>("Price"))
                };
