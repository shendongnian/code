    List<Items> objItems = new List<Items>();
            objItems.Add(new Items(1,"Rahul"));
            objItems.Add(new Items(2, "Rohit"));
            objItems.Add(new Items(1, "Kumar"));
            objItems.Add(new Items(2, "Verma"));
            List<Items> objNew = new List<Items>(); //it will hold result
            string str = "";
            for (int i = 0; i < objItems.Count; i++)
            {
                if (objItems[i].ID > 0)
                {
                    str = objItems[i].Text;
                    for (int j = i + 1; j < objItems.Count; j++)
                    {
                        if (objItems[i].ID == objItems[j].ID)
                        {
                            str += objItems[j].Text + " ";
                            objItems[j].ID = -1;
                        }
                    }
                    objNew.Add(new Items(objItems[i].ID, str));
                }
            }
