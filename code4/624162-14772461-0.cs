            List<String> lst = new List<string>();
            lst.Add("Life Skills");
            lst.Add("Life Skills");
            lst.Add("Communication");
            lst.Add("Careers; Listening Skills;Life Skills; Personal Development; Questioning Skills; Coaching/Mentoring; Recognition; Recruitment and Selection.");
            lst.Add("No Related Topics");
            List<string> newList = new List<string>();
            foreach (string str in lst)
            {
                var temp = str.Split(';');
                if (temp.Length > 1)
                {
                    for (int i = 0; i < temp.Length; i++)
                    {
                        if (!newList.Contains(temp[i]))
                        {
                            newList.Add(temp[i]);
                        }
                    }
                }
                else
                {
                    if (!newList.Contains(str))
                    {
                        newList.Add(str);
                    }
                }
            }
