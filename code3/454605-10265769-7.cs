        public static Dictionary<string, List<Student>> GetStudentGroups()
        {
            var temp = from s in students
                       let grps = s.StudentGroup.ConvertAll(gn => gn.GroupName)
                       from grp in grps
                       group s by grp
                       into g
                       select g;
            return temp.ToDictionary(grping => grping.Key, studnt => studnt.ToList());
        }
