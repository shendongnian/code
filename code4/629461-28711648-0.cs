	public class MyClass {
		public string HierarchyId {
			get;
			set;
		}
		[Ignore]
		public SqlHierarchyId SqlHierarchyId {
			get {
				return SqlHierarchyId.Parse(new SqlString(HierarchyId));
			}
			set {
				HierarchyId = value.ToString();
			}
		}
	}
