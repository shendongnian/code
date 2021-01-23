        public string Name { get; set; }
        public int Value { get; set; }
    }
    public class Player
    {
        public string Name { get; set; }
        public ICollection<Skill> Skills { get; set; }
    }
    public static void Main(string[] args)
    {
        List<Skill> skillsA = new List<Skill>();
        List<Skill> skillsB = new List<Skill>();
        List<Skill> skillsC = new List<Skill>();
        List<Skill> skillsD = new List<Skill>();
        skillsA.Add(new Skill() { Name = "Speed", Value = 1 });
        skillsA.Add(new Skill() { Name = "Agility", Value = 5 });
        skillsA.Add(new Skill() { Name = "Strength", Value = 3 });
        skillsA.Add(new Skill() { Name = "Endurance", Value = 4 });
        skillsB.Add(new Skill() { Name = "Speed", Value = 5 });
        skillsB.Add(new Skill() { Name = "Agility", Value = 2 });
        skillsB.Add(new Skill() { Name = "Strength", Value = 1 });
        skillsB.Add(new Skill() { Name = "Endurance", Value = 3 });
        skillsC.Add(new Skill() { Name = "Speed", Value = 5 });
        skillsC.Add(new Skill() { Name = "Agility", Value = 3 });
        skillsC.Add(new Skill() { Name = "Strength", Value = 2 });
        skillsC.Add(new Skill() { Name = "Endurance", Value = 2 });
        skillsD.Add(new Skill() { Name = "Speed", Value = 1 });
        skillsD.Add(new Skill() { Name = "Agility", Value = 2 });
        skillsD.Add(new Skill() { Name = "Strength", Value = 5 });
        skillsD.Add(new Skill() { Name = "Endurance", Value = 4 });
        Player A = new Player() { Name = "A", Skills = skillsA };
        Player B = new Player() { Name = "B", Skills = skillsB };
        Player C = new Player() { Name = "C", Skills = skillsC };
        Player D = new Player() { Name = "D", Skills = skillsD };
        List<Skill> matchSkills = new List<Skill>();
        matchSkills.Add(new Skill() { Name = "Speed", Value = 5 });
        matchSkills.Add(new Skill() { Name = "Agility", Value = 2 });
        matchSkills.Add(new Skill() { Name = "Strength", Value = 1 });
        matchSkills.Add(new Skill() { Name = "Endurance", Value = 1 });
        Player[] players = new Player[] { A, B, C, D };
        IEnumerable<Player> orderedPlayers = players.OrderBy(player => player.Skills.Sum(playerSkill => Math.Abs(playerSkill.Value - matchSkills.First(matchSkill => matchSkill.Name == playerSkill.Name).Value)));
    }
