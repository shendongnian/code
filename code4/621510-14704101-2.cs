	abstract class PhoneBookCore {
		protected string _group;
		public PhoneBookCore(string group) {
			this._group=group;
		}
		public virtual void Add(PhoneBookCore d) {
		}
	}
	class Contect: PhoneBookCore {
		private string _firstName;
		private string _lastName;
		private string _phoneNumber;
		private string _addres;
		public override String ToString() {
			return
				(new[] { _firstName, _lastName, _phoneNumber, _addres }).Aggregate((a, b) => a+"\t"+b);
		}
		public Contect(string group, string firstName, string lastName, string phoneNumber, string addres)
			: base(group) {
			this._firstName=firstName;
			this._addres=addres;
			this._lastName=lastName;
			this._phoneNumber=phoneNumber;
		}
	}
	class Group: PhoneBookCore, IEnumerable<String> {
		IEnumerator IEnumerable.GetEnumerator() {
			return this.GetEnumerator();
		}
		public IEnumerator<String> GetEnumerator() {
			return elements.Select(x => x.ToString()).GetEnumerator();
		}
		private List<PhoneBookCore> elements=new List<PhoneBookCore>();
		public List<PhoneBookCore> elementsList {
			get;
			set;
		}
		public Group(string name)
			: base(name) {
		}
		public override void Add(PhoneBookCore d) {
			elements.Add(d);
		}
	}
	class DataOptins {
		public string Save(Group g) {
			string[] arr=g.ToArray(); // <---- :(
			System.IO.File.WriteAllLines(Path, arr); // <---- :(
			// notice: you did not show what to return in original code
		}
	}
