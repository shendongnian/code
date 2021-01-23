    static void ShowCombination(List<string> mlist, int value,int current=0,string stringleft="")
        {
                if (current == mlist.Count-1)
                {
                    for (int m = 0; m <= value; m++)
                    {
                        Console.WriteLine(stringleft  + mlist[current]+m.ToString());
                    }
                }
                else
                {
                    string currentstring = mlist[current];
                    stringleft = stringleft + currentstring ;
                    for (int m = 0; m <= value; m++)
                    {
                        string stopass = stringleft +  m.ToString();
                        ShowCombination(mlist, value, current + 1, stopass);
                    }
                }
        }
