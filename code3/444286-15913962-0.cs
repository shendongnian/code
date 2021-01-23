        private ArrayList RemoveSearchDuplicates(ArrayList SearchResults)
        {
            ArrayList TempList = new ArrayList();
            foreach (User u1 in SearchResults)
            {
                bool duplicatefound = false;
                foreach (User u2 in TempList)
                    if (u1.ID == u2.ID)
                        duplicatefound = true;
                if (!duplicatefound)
                    TempList.Add(u1);
            }
            return TempList;
        }
