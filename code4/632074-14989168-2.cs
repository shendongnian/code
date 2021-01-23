    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ConsoleApplication3.Models;
    using NHibernate.Cfg;
    using NHibernate.Tool.hbm2ddl;
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                var cfg = new Configuration();
                cfg.Configure();
                cfg.AddAssembly(typeof(LinkDAO).Assembly);
                new SchemaExport(cfg).Execute(script: true, export: true, justDrop: true);
                new SchemaExport(cfg).Execute(script:true, export:true, justDrop:false);
                var objAs = new ObjectADAO[] { new ObjectADAO { Name = "A1" }, new ObjectADAO { Name = "A2" } };
                var objBs = new ObjectBDAO[] { new ObjectBDAO { Name = "B1" }, new ObjectBDAO { Name = "B2" } };
                using (var _sessionFactory = cfg.BuildSessionFactory())
                {
                    using (var session = _sessionFactory.OpenSession())
                    {
                        using (var tran = session.BeginTransaction())
                        {
                            objAs.ToList().ForEach(x => session.Save(x));
                            objBs.ToList().ForEach(x => session.Save(x));
                            tran.Commit();
                        }
                        using (var tran = session.BeginTransaction())
                        {
                            session.Save(new LinkDAO { ObjectA = objAs[0], ObjectB = objBs[1] });
                            session.Save(new LinkDAO { ObjectA = objAs[1], ObjectB = objBs[0] });
                            tran.Commit();
                        }
                        IList<LinkDAO> links = session.QueryOver<LinkDAO>().List();
                        links.ToList().ForEach(lk => Console.WriteLine("{0} {1}", lk.ObjectA.Name, lk.ObjectB.Name));
                        var ids = session.QueryOver<LinkDAO>().Select(x => x.ObjectA.Id, x => x.ObjectB.Id ).List<object[]>();
                        ids.ToList().ForEach(ary => Console.WriteLine("{0} {1}", ary[0], ary[1]));
                    }
                }
            }
        }
    }
