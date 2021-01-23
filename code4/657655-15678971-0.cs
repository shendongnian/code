            int i = 0;
            while (i != leftIndex.Id )
            {
                foreach (var s in StatusList.ToList())
                {
                    if (s.Count == 0) { StatusList.Remove(s); }
                     
                    if (i == leftIndex.Id) break;
                    i++;
                }
            }
            var StatusListCleanLeft = new List<StatusData>();
            StatusListCleanLeft = StatusList;
            
            //  2. trimming the right side
            StatusListCleanLeft.Reverse();
            var newIndex = StatusListCleanLeft.First(x => x.Count != 0);
            int j = 0;
            while (j != newIndex.Id)
            {
                foreach (var t in StatusListCleanLeft.ToList())
                {
                    if (t.Count == 0) { StatusListCleanLeft.Remove(t); }
                    if (t == newIndex.Id) break;
                    j++;
                }
            }
            StatusListCleanLeft.Reverse();
