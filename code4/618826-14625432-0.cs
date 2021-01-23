    Dictionary<string, Dictionary<string, int>> dict = new Dictionary<string, Dictionary<string, int>>();
        foreach (var item in TrainingCourseList)
        {
            // i have to add item.ID,item.Name,item.Score something like below
            dict.Add(item.ID,new Dictionary<string,int>{{item.Name,item.Score}};
        }
