    foreach (parseAC item in pACList.Where(i=>pList.Any(x => (x.CompanyId == i.key.ToString()))))
        {
                pItem = pList.Find(x => (x.CompanyId == item.key.ToString()));
                //Processing done here.  pItem gets updated here
                ...
        }
