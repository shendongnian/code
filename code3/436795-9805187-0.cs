       Boolean flag_size = false;
        Boolean flag_adate = false;
        Boolean flag_cdate = false;
        Boolean flag_mdate = false;
        Int64 sz=0;
        DateTime adatetest=DateTime.Now;
        DateTime cdatetest = DateTime.Now;
        DateTime mdatetest = DateTime.Now;
        String mop = mdateop.Text;
        String aop = adateop.Text;
        String cop = cdateop.Text;
        if (fsize.Text.Trim() != "")
        {
            try
            {
                sz = Int64.Parse(fsize.Text);
                flag_size = true;
            }
            catch { }
        }
        if (adate.Text.Trim() != "")
        {
            try
            {
                adatetest = DateTime.Parse(adate.Text);
                flag_adate = true;
            }
            catch
            { }
        }
        if (cdate.Text.Trim() != "")
        {
            try
            {
                cdatetest = DateTime.Parse(cdate.Text);
                flag_cdate = true;
            }
            catch
            { }
        }
        if (mdate.Text.Trim() != "")
        {
            try
            {
                mdatetest = DateTime.Parse(mdate.Text);
                flag_mdate = true;
            }
            catch
            { }
        }
        foundfiles = new BindingList<f_results>(totalresults.Find(fname.Text, true));
                List<f_results> y = (from p in foundfiles.AsParallel() 
                                     where  (!flag_size || (flag_size && p.size >= sz)) &&
                                            (!flag_mdate || (flag_mdate && mop == ">" && p.mdate >= mdatetest) || (flag_mdate && mop == "< " && p.mdate >= mdatetest)) &&
                                            (!flag_adate || (flag_adate && aop == ">" && p.adate >= adatetest) || (flag_adate && aop == "< " && p.adate >= adatetest)) &&
                                            (!flag_cdate || (flag_cdate && cop == ">" && p.cdate >= cdatetest) || (flag_cdate && cop == "< " && p.cdate >= cdatetest))
                                     orderby p.size descending 
                                     select p).ToList();
                foundfiles = new BindingList<f_results>(y);
