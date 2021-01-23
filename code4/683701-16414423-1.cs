    public IEnumerable<ListViewItem> splitSNS(string fullSNSpath)
        {
            string sns = new String(fullSNSpath.ToCharArray().Where(c => Char.IsDigit(c)).ToArray());
            if (sns.Length.ToString() == "6")
            {
                string sys = sns.Substring(4, 2);
                string subsys = sns.Substring(2, 2);
                string unit = sns.Substring(0, 2);
               IEnumerable<ListViewItem> dms = getDMcollection(sys, subsys, unit);
               foreach(var d in dms)
                   yield return d;
            }
            else if (sns.Length.ToString() == "4")
            {
                string sys = sns.Substring(2, 2);
                string subsys = sns.Substring(0, 2);
               IEnumerable<ListViewItem> dms = getDMcollection(sys, subsys);
               foreach(var d in dms)
                   yield return d;
            }
            else if (sns.Length.ToString() == "2")
            {
                string sys = sns.Substring(0, 2);
               IEnumerable<ListViewItem> dms = getDMcollection(sys);
               foreach(var d in dms)
                   yield return d;
            }
        }
