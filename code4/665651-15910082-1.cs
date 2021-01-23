            class Project
            {
                public int? id;
                public Project(int? iid) { id = iid; }
            }
            public class Program
            {
                static void Main(string[] args)
                {
                    List<Project> pros = new List<Project>() { new Project(null), new Project(10), new Project(50), new Project(1), new Project(null) };
                    var x = new Comparison<Project>((Project r, Project l) =>
                        {
                            if (r.id == null && l.id == null)
                                return 0;
                            if (r.id == null)
                            {
                                return 1;
                            }
                            if (l.id == null)
                            {
                                return -1;
                            }
                            return Math.Sign(r.id.Value - l.id.Value);
                        });
                    pros.Sort(x);
                    Console.ReadLine();
                }                
            }
