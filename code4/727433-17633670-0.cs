        public static List<int> FindMyLegs(List<Leg> allLegs, int startPt, int endPt)
        {
            var result = new List<int>();
            var pre_result = allLegs.Where(l => (l.p1Id >= startPt && l.p2Id <= endPt) || (l.p2Id <= startPt && l.p1Id >= endPt));
            foreach (var leg in pre_result)
            {
                result.Add(leg.p1Id);
                result.Add(leg.p2Id);
            }
            result = (startPt > endPt ? result.OrderBy(t => t) : result.OrderByDescending(t => t)).Distinct().ToList();
            return result;
        }
        static void Main()
        {
            var legs = new List<Leg>();
            var l1 = new Leg { p1Id = 1, p2Id = 2 };
            var l2 = new Leg { p1Id = 4, p2Id = 5 };
            var l3 = new Leg { p1Id = 2, p2Id = 3 };
            var l4 = new Leg { p1Id = 5, p2Id = 6 };
            var l5 = new Leg { p1Id = 3, p2Id = 4 };
            legs.Add(l1);
            legs.Add(l2);
            legs.Add(l3);
            legs.Add(l4);
            legs.Add(l5);
            var myLegs = FindMyLegs(legs, 2, 5);
            foreach (var leg in myLegs)
            {
                Console.WriteLine(leg);
            }
        }    
