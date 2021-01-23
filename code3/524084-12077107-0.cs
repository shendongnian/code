    namespace AppLib
    {
        /// <summary> 
        /// Entry point for library. Stage manages all the actors in the logic. 
        /// </summary> 
        class StageApp
        {
            /// <summary> 
            /// Setting that is looked up by different actors 
            /// </summary> 
            public int SharedSetting { get; set; }
    
            /// <summary> 
            /// Stage managing actors with app logic 
            /// </summary> 
            public IEnumerable<Actor> Actors { get { return m_actors.Where(x => x.Execute() > 40).ToArray(); } }
    
            private List<Actor> m_actors = new List<Actor>();
    
            public int TotalActorsCount
            {
                get
                {
                    return m_actors.Count;
                }
            }
    
            public void AddActor(Actor actor)
            {
                if (actor == null)
                    throw new ArgumentNullException("actor");
    
                if (m_actors.Contains(actor))
                    return; // or throw an exception
    
                m_actors.Add(actor);
                if (actor.Stage != this)
                {
                    actor.Stage = this;
                }
            }
    
            // we are hiding this method, to avoid because we can change Stage only to another non null value
            // so calling this method directly is not allowed
            internal void RemoveActor(Actor actor)
            {
                if (actor == null)
                    throw new ArgumentNullException("actor");
    
                if (!m_actors.Contains(actor))
                    return; // or throuw exception
    
                m_actors.Remove(actor);
            }
        }
    
        /// <summary> 
        /// An object on the stage. Refers to stage (shared)settings and execute depending on the settings. 
        /// Hence actor should have reference to stage 
        /// </summary> 
        class Actor
        {
            private StageApp m_StageApp;
    
            private int m_Property;
    
            public StageApp Stage
            {
                get
                {
                    return m_StageApp;
                }
                set
                {
                    if (value == null)
                    {
                        throw new ArgumentNullException("value");
                    }
                    if (m_StageApp != value)
                    {
                        if (m_StageApp != null) // not a call from ctor
                        {
                            m_StageApp.RemoveActor(this);
                        }
                        m_StageApp = value;
                        m_StageApp.AddActor(this);
                    }
                }
            }
    
            /// <summary> 
            /// An actor that needs to refer to stage to know what behavior to execute 
            /// </summary> 
            /// <param name="stage"></param> 
            public Actor(StageApp stage)
            {
                Stage = stage;
                m_Property = new Random().Next();
            }
    
            /// <summary> 
            /// Execute according to stage settings 
            /// </summary> 
            /// <returns></returns> 
            public int Execute()
            {
                return m_StageApp.SharedSetting * m_Property;
            }
        }
    }
    
    namespace AppExe
    {
        using AppLib;
    
        class Program
        {
            static void Main(string[] args)
            {
                StageApp app = new StageApp();
                app.SharedSetting = 5;
    
                StageApp anotherApp = new StageApp();
                anotherApp.SharedSetting = 6;
    
                // actor is added to the stage automatically after instantiation
                Actor a1 = new Actor(app);
                Actor a2 = new Actor(app);
                Actor a3 = new Actor(anotherApp);
    
                Console.WriteLine("Actors in anotherApp before moving actor:");
                Console.WriteLine(anotherApp.TotalActorsCount);
    
                // or by calling method from StageApp class
                anotherApp.AddActor(a1);
    
                Console.WriteLine("Actors in anotherApp after calling method (should be 2):");
                Console.WriteLine(anotherApp.TotalActorsCount);
                
                // or by setting Stage through property
                a2.Stage = anotherApp;
    
                Console.WriteLine("Actors in anotherApp after setting property of Actor instance (should be 3):");
                Console.WriteLine(anotherApp.TotalActorsCount);
                
                Console.WriteLine("Actors count in app (should be empty):");
                Console.WriteLine(app.TotalActorsCount);
            }
        }
    }
