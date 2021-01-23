        //example
        List<string> texts = new List<string>();
        List<int> integers = new List<int>();
        for (int j = 1; j <= 10; j++)
        {
            text.Add("00" + j.ToString());
            integers.Add(j);
        }
        var a = from t in texts
                join i in integers on Convert.ToInt32(t) equals i
                select t;
