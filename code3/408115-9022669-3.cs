    var uniqueCatRes = from d in tblData.AsEnumerable()
                       group d by new{Cat= d["Category"], Res=d["Resourceworked"]} into Group 
                       select Group;
    var catResCount = from grp in uniqueCatRes
                      let CatName = grp.Key.Cat
                      let ResName = grp.Key.Res
                      let ResCount = grp.Count()
                      select new { CatName, ResName, ResCount };
    summary = from crc in catResCount
              select string.Format("Cat:{0} Res:{1} Count:{2}", crc.CatName,crc.ResName , crc.ResCount);
    message = string.Join(Environment.NewLine, summary);
    MessageBox.Show(message);
