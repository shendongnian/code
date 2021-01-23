    Context.TableOne.Select(
        one =>
            new
            {
                One = one,
                TwoCount = one.TableTwo.Count()
            });
