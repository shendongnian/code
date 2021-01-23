	namespace AppExe
	{
		using AppLib;
	class Program
		{
			static void Main(string[] args)
			{
				StageApp app = new StageApp();
				app.CreateActor();
				app.SharedSetting = 5;
				foreach (var actor in app.Actors)
					Console.WriteLine(actor.Execute());
			}
		}
	}
	namespace AppLib
	{
		class StageApp
		{
			public int SharedSetting { get; set; }
			public IEnumerable<Actor> Actors { get { return m_actors.Where(x => x.Execute() > 40).ToArray(); } }
			private List<Actor> m_actors = new List<Actor>();
			public void CreateActor()
			{
				m_actors.Add(new Actor(Executed));
			}
			private int Executed(int arg)
			{
				return SharedSetting * arg;
			}
		}
		class Actor
		{
			private int m_Property;
			private Func<int, int> m_executed;
			public Actor(Func<int, int> executed)
			{
				m_executed = executed;
				m_Property = new Random().Next();
			}
			public int Execute()
			{
				return m_executed(m_Property);
			}
		}
	}
