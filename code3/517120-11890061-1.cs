        public static StringBuilder GetFamilyTree(List<MyEntity> AllTheEntities)
        {
            StringBuilder Return = new StringBuilder();
            List<MyEntity> OrderedEntities = AllTheEntities.OrderBy<MyEntity, int>(x => x.ID).ToList();
            foreach (MyEntity CurrentEntity in AllTheEntities.Where<MyEntity>(x => !x.ParentID.HasValue))
            {
                Return.AppendLine(GetEntityTree(AllTheEntities, CurrentEntity));
            }
            return Return;
        }
        public static string GetEntityTree(List<MyEntity> AllTheEntities, MyEntity CurrentEntity, int CurrentLevel = 0)
        {
            StringBuilder Return = new StringBuilder();
            Return.AppendFormat("{0}{1}", "\t".Repeat(CurrentLevel), CurrentEntity.Name);
            Return.AppendLine();
            List<MyEntity> Children = AllTheEntities.Where<MyEntity>(x => x.ParentID.HasValue && x.ParentID.Value == CurrentEntity.ID).ToList();
            
            if (Children != null && Children.Count > 0)
            {
                foreach (MyEntity CurrentChildEntity in Children)
                {
                    Return.Append(GetEntityTree(AllTheEntities, CurrentChildEntity, CurrentLevel + 1));
                }
            }
            return Return.ToString();
        }
