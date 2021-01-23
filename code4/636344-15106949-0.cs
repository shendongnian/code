        List<Products> productList = new List<Products>();
        using (IDataReader rdr = dbt.ExecuteReader("pGetProducts",p.productType))
        {
           do
           {
              while (rdr.Read())
              {
                Products obj= new Products();
                {
                    obj.Id = Common.CheckIntegerNull(rdr["id"]);
                    obj.AId = Common.CheckIntegerNull(rdr["aid"]);
                    obj.Name = Common.CheckStringNull(rdr["name"]);
                    obj.Price = Common.CheckDecimalNull(rdr["amt"]);
                }
                productList.Add(obj);
              }
            } while (rdr.NextResult());
          return productList;
        }
    }
