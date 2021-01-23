                    double dd;
                    Dictionary<string, double> dic;
                    bool notin = this.summedVars.TryGetValue(bacino, out dic);
                    dic = dic ?? new Dictionary<string,double>();
                    if(notin == false)
                        this.summedVars.Add(bacino,dic);
                    dic.TryGetValue(id, out dd);
                    dic[id] = dd + d;
