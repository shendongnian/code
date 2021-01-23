    public class SomeMapper : ISomeMapper {
        public List<SomeType> Map(dynamic resultSet) {
            return resultSet.Select(new SomeType {
                Prop1 = currentGroup.Item.Id,
                Prop2 = currentGroup.Item.Name,
                Prop3 = ((IEnumerable<AnotherType>)resultSet.SomeMembers).OrderBy(x => x.Name)
            }).ToList();
        }
    }
