            var data = GetData();
            foreach (var v0 in data)
            {
                if (v0.Key.Item3 != string.Empty) continue;
                //Get all related data 
                var tr_line = data[v0.Key];
                sb.AppendLine(tr_line.First());
                var hhLines = from v1 in data
                              where v1.Key.Item2 == string.Empty &&
                                    v1.Key.Item1 == v0.Key.Item1
                              select data[v1.Key];
                foreach (var hh_line in hhLines)
                {
                    sb.AppendLine(hh_line.First());
                    var grouping = v0;
                    var enumerable = from v2 in data
                                     where v2.Key.Item1 == grouping.Key.Item1 &&
                                           v2.Key.Item2 != string.Empty &&
                                           v2.Key.Item3 != string.Empty
                                     select data[v2.Key].OrderByDescending(r => r)
                                     into hl_sl_lines from v3 in hl_sl_lines select v3;
                    foreach (var v3 in enumerable)
                    {
                        sb.AppendLine(v3);
                    }
                }
            }
