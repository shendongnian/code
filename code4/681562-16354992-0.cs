    var keysForMaxP1 = dict.Aggregate(
                           new { Max = double.MinVal, Keys = new List<int>()},
                           (state, entry) => {
                               if (entry.Value.P1 > state.Max) {
                                   state.Max = entry.Value.P1;
                                   state.Keys = new List<int>() { entry.Key };
                               } else if (entry.Value.P1 == state.Max) {
                                   state.Keys.Add(entry.Key);
                               }
                               return state;
                           }, state => state.Keys);
