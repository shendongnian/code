        public class SKillIDDemo
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string SkillSetID { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                List<SKillIDDemo> demos = new List<SKillIDDemo>();
    
                demos.Add(new SKillIDDemo() { ID = 1, Name = "demo1", SkillSetID = "10,1" });
                demos.Add(new SKillIDDemo() { ID = 2, Name = "demo2", SkillSetID = "10" });
                demos.Add(new SKillIDDemo() { ID = 3, Name = "demo3", SkillSetID = "1" });
                demos.Add(new SKillIDDemo() { ID = 4, Name = "demo4", SkillSetID = "12" });
    
                string[] skillset = { "10","1" };
                
                var testme =   demos.Where(x=> skillset.Any(a=> x.SkillSetID.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries).Contains(a))).ToList();
    
                testme.ForEach(g=> Console.WriteLine(g.Name));  
    
                Console.ReadLine();
            }
        }
    
