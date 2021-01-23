    using System;
    using System.IO;
    using System.Linq;
    using Db4objects.Db4o;
    using Db4objects.Db4o.Activation;
    using Db4objects.Db4o.TA;
    namespace ActivationDepth
    {
        class Program
        {
            static void Main(string[] args)
            {
                var dbFilePath = Path.GetTempFileName();
                using (var db = Db4oEmbedded.OpenFile(dbFilePath))
                {
                    db.Store(new C1 { Name = "c1", Huge = new MyHugeClass("I am really huge....")});
                }
                
                var config = Db4oEmbedded.NewConfiguration();
                config.Common.Add(new TransparentActivationSupport());
                config.Common.ActivationDepth = 0;
                using (var db = Db4oEmbedded.OpenFile(config, dbFilePath))
                {
                    var item = db.Query<C1>().ElementAt(0);
                    
                    Console.WriteLine("{0}", db.Ext().IsActive(item));
                    Console.WriteLine("[Huge] {0} : {1}", db.Ext().IsActive(item.huge), item.huge);
                    Console.WriteLine("[Huge] {0} : {1}", db.Ext().IsActive(item.Huge), item.Huge);
                }
            }
        }
        class C1 : IActivatable
        {
            public string Name
            {
                get
                {
                    Activate(ActivationPurpose.Read);
                    return name;
                }
                set
                {
                    Activate(ActivationPurpose.Write);
                    name = value;
                }
            }
            public MyHugeClass Huge
            {
                get
                {
                    Activate(ActivationPurpose.Read);
                    return huge;
                }
                set
                {
                    Activate(ActivationPurpose.Write);
                    huge = value;
                }
            }
            public override string ToString()
            {
                Activate(ActivationPurpose.Read);
                return string.Format("[{0}] {1}", GetType().Name, name);
            }
            public void Bind(IActivator activator)
            {
                if (this.activator != null && activator != null)
                {
                    throw new Exception("activation already set");
                }
                this.activator = activator;
            }
            public void Activate(ActivationPurpose purpose)
            {
                if (activator != null)
                {
                    activator.Activate(purpose);
                }
            }
            public MyHugeClass huge;
            private string name;
            [NonSerialized]
            private IActivator activator;
        }
        class MyHugeClass : IActivatable
        {
            public string Name
            {
                get
                {
                    Activate(ActivationPurpose.Read);
                    return name;
                }
                set
                {
                    Activate(ActivationPurpose.Write);
                    name = value;
                }
            }
            
            public MyHugeClass(string name)
            {
                this.name = name;
            }
            
            public override string ToString()
            {
                Activate(ActivationPurpose.Read);
                return string.Format("[{0}] {1}", GetType().Name, name);
            }
            public void Bind(IActivator activator)
            {
                if (this.activator != null && activator != null)
                {
                    throw new Exception("activation already set");
                }
                this.activator = activator;
            }
            public void Activate(ActivationPurpose purpose)
            {
                if (activator != null)
                {
                    activator.Activate(purpose);
                }
            }
            private string name;
            [NonSerialized]
            private IActivator activator;
        }
    }
