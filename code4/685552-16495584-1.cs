	[Flags]
	public enum Permission {
		None = 0,
		GetName = 1
	}
	public abstract class Person {
		/* ... */
		public abstract Permission Permissions { get; }
	}
	public class Staff : Person {
		/* ... */
		public override Permission Permissions {
			get { return Permission.GetName; }
		}
	}
	public class Student : Person {
		/* ... */
		public override Permission Permissions {
			get { return Permission.None; }
		}
	}
	public class Database {
		/* ... */
		private Dictionary<string, string> NamesDatabase { get; set; }
		public string getName(string id) {
			// As a consequence of being managed by Gateway, assume that the caller has access
			return NamesDatabase[id];
		}
	}
	public class Gateway {
		public string DoSomethingWithPerson(Person person, string desiredNamePersonId) {
			if (person.Permissions.HasFlag(Permission.GetName)) {
				Database db = new Database();
				return db.getName(desiredNamePersonId);
			}
			return "go away!";
		}
	}
