            List<Decimal> consArray = new List<decimal>();
            try
            {
                Decimal d;
                Assert.IsTrue(Decimal.TryParse(item.Value, out d));
                consArray.Add(d);
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(item.Value);
                Console.WriteLine(e);
            }
