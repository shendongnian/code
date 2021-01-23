    string baseLineFolder=dt.Rows["BASELINE_FOLDER"].ToString();
                    string baseLineFile=dt.Rows["BASELINE_FILE"].ToString();
                    string baseLineChecksum=dt.Rows["BASELINE_CHECKSUM"].ToString();
                    var dtresult = dt.AsEnumerable();
                    var result=(from r in dtresult
                                where(r.Field<string>("BASELINE_FOLDER")!=baseLineFolder)
                                &&(r.Field<string>("BASELINE_FILE")!=baseLineFile)
                                &&(r.Field<string>("BASELINE_CHECKSUM ")!=baseLineChecksum)
                                  select r).ToList();
