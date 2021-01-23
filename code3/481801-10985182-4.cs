    //Please give me a real name
    public class ClassToBeRenamed
    {
        public DateTime Time { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    List<ClassToBeRenamed[]> myList = new List<ClassToBeRenamed[]>();
    
    for (int i = 0; i < 10; i++)
    {
    myList.Add((from p in _rep.GetMetricsData().GetLHDb().page_loads
                where p.t_3id == sID && p.test_path_id == i
                select new ClassToBeRenamed { Time = p.time, CreatedAt = p.created_at })
                .ToArray());
    }
