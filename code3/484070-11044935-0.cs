        public static void FillDest<T>(IList<T> dest, IList<IList<T>> srcLists)
            where T : class
        {
            bool goon = true;
            int idx = 0;
            dest.Clear();
            while (goon)
            {
                goon = false;
                bool added = true;
                foreach (IList<T> aSrc in srcLists)
                {
                    added = false;
                    T anItem;
                    if (aSrc.Count <= idx)
                    {
                        added = true;
                        continue;
                    }
                    goon = true;
                    if ((anItem = aSrc[idx]) != null)
                    {
                        dest.Add(anItem);
                        added = true;
                        break;
                    }
                }
                if (!added)
                    dest.Add((T)null);
                idx++;
            }
        }
