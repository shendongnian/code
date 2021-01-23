      var dtThen = DateTime.UtcNow.AddHours(-24);
                    var dtNow = DateTime.UtcNow;
                    
                    var logs = this._wadLogs.WadLogs.Where(
                        wl => 
                            wl.Level == 2 
                            && String.Compare(wl.PartitionKey,"0" + dtThen.Ticks.ToString()) >=0
                            && String.Compare(wl.PartitionKey, "0" + dtNow.Ticks.ToString()) < 0
                        ).Take(200);
