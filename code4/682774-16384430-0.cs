     List<student> students = new List<student>
            {
                new student{id="1",state="close",evaluation=5},
                new student{id="1",state="close",evaluation=4}
            };
            double avg = (students.Where(r => (r.id == "1" && r.state == "close")).Average(r => r.evaluation));
    
    public class student
    {
        public string id { get; set; }
        public string state { get; set; }
        public int evaluation { get; set; }
    }
