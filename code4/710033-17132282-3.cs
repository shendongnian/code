    public string HijriToGreg(string hijri,string format)
            {
                
                if (hijri.Length<=0)
                {
                    
                    cur.Trace.Warn("HijriToGreg :Date String is Empty");
                    return "";
                }
                try
                {
                    DateTime tempDate=DateTime.ParseExact(hijri,
                       allFormats,arCul.DateTimeFormat,DateTimeStyles.AllowWhiteSpaces);
                    return tempDate.ToString(format,enCul.DateTimeFormat);
                    
                }
                catch (Exception ex)
                {
                    cur.Trace.Warn("HijriToGreg :"+hijri.ToString()+"\n"+ex.Message);
                    return "";
                }
            }
