             public List<MySPEntity> GetMyData(int thirdValue, string firstValue)
            {
                    var paraOne = new SqlParameter("@One", firstValue);
                    var paraTwo = new SqlParameter("@Two", DBNull.Value);
                    var paraThree = new SqlParameter("@Three", thirdValue);
                    var paraFour = new SqlParameter("@Four", DBNull.Value);
                    var result = DataContext.Database.SqlQuery<MySPEntity>("EXEC SP_MySP @One, @Two, @Three, @Four"
                    , paraTwo, paraOne, paraFour,paraThree).ToList();
                    return result;
              
            }
