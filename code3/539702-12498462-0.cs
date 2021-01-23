    spmOne = _pumpOneSpm
              .Zip(_pumpTwoSpm, (pump1, pump2) => new { pump1, pump2 } )
              .Zip(_date, (x, pumpDate) => new { x.pump1, x.pump2, date = pumpDate })
              .Zip(_time, (x, time) => new { x.pump1, x.pump2, x.date, time })
              .Where(x => x.date.Equals(date) &&
                          DateTime.Compare(x.time, DateTime.Parse(start)) > 0 &&
                          DateTime.Compare(x.time, DateTime.Parse(end)) < 0)
              .SelectMany(x => new [] { x.pump1, x.pump2 })
              .ToList();
