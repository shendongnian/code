    using System;
    using System.IO;
    using System.Linq;
    using Db4objects.Db4o;
    using Db4objects.Db4o.Events;
    namespace ActivationDepth
    {
        class Program
        {
            static void Main(string[] args)
            {
                var dbFilePath = Path.GetTempFileName();
                using (var db = Db4oEmbedded.OpenFile(dbFilePath))
                {
                    db.Store(new C1 { name = "c1", c2 = new C2("c2"), huge = new MyHugeClass("I am really huge....")});
                }
                
                var config = Db4oEmbedded.NewConfiguration();
                using (var db = Db4oEmbedded.OpenFile(config, dbFilePath))
                {
                    var activate = false;
                    var fac = EventRegistryFactory.ForObjectContainer(db);
                    fac.Activating += (sender, eventArgs) =>
                    {
                        if (!activate && eventArgs.Object.GetType() == typeof(MyHugeClass))
                        {
                            Console.WriteLine("[{0}] Ignoring activation.", eventArgs.Object);
                            eventArgs.Cancel();
                        }
                        else
                        {
                            Console.WriteLine("[{0}] Activation will proceed.", eventArgs.Object);
                        }
                    };
                    var item = db.Query<C1>().ElementAt(0);
                    Console.WriteLine("[IsActive] {0}", db.Ext().IsActive(item.huge));
                    activate = true;
                    db.Activate(item.huge, 3);
                    Console.WriteLine("[IsActive] {0}", db.Ext().IsActive(item.huge));
                }
            }
        }
        class C1
        {
            public string name;
            public C2 c2;
            public MyHugeClass huge;
            public override string ToString()
            {
                return string.Format("[{0}] {1}", GetType().Name, name);
            }
        }
        class C2
        {
            public string name;
            public C2(string name)
            {
                this.name = name;
            }
            
            public override string ToString()
            {
                return string.Format("[{0}] {1}", GetType().Name, name);
            }
        }
        class MyHugeClass
        {
            public string text;
            public MyHugeClass(string text)
            {
                this.text = text;
            }
            public override string ToString()
            {
                return string.Format("[{0}] {1}", GetType().Name, text);
            }
        }
    }
