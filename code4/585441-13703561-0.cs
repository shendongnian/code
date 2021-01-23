    Question[] arr = new Question[4];
    
        Random rnd = new Random();
    
        int i = 0;
        int temp = 0;
        bool ok = false;
    
        while (i < 3)
        {
            temp = rnd.Next(0, Int32.Parse(dt_count.Rows[0][0].ToString()) - 1);
            for (int j = 0; j < arr.Length; j++)
            {
                arr[j] = new Question();
                arr[j].id = Int32.Parse(dt_q_notMust.Rows[temp][0].ToString());  // ID
                arr[j].question = dt_q_notMust.Rows[temp][1].ToString();  // Question
                arr[j].a1 = dt_q_notMust.Rows[temp][2].ToString();  // A1
                arr[j].a2 = dt_q_notMust.Rows[temp][3].ToString();   // A2
                arr[j].a3 = dt_q_notMust.Rows[temp][4].ToString();  // A3
                arr[j].a4 = dt_q_notMust.Rows[temp][5].ToString();  // A4
                arr[j].Tanswer = Int32.Parse(dt_q_notMust.Rows[temp][6].ToString());  // True Answer (int).
    
                if (arr[j].id != temp)
                {
                    ok = true;
    
                }
            }
    
            if (ok)
            {
                i++;
            }
        }
