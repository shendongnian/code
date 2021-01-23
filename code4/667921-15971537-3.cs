    _efContext.GameResult
              .Where(game => game.ContenderSecond_ContenderId  == 42)
              .Select(game => new { 
                    ContendersName = game.ContenderSecond.Name
                  , Win = game.ScoreContenderFirst < game.ScoreContenderSecond
                  , Draw = game.ScoreContenderFirst == game.ScoreContenderSecond
                  , Lose = game.ScoreContenderFirst > game.ScoreContenderSecond
                  })
              .GroupBy(game => game.ContendersName)
              .Select(grp => new {
                  ContendersName= grp.Key
                , Wins = grp.Where(game => game.Win).Count()
                , Draws = grp.Where(game => game.Draw).Count()
                , Loses = grp.Where(game => game.Lose).Count()
           })
