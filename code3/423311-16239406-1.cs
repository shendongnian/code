    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using Neo4jClient;
    namespace Neo4jClientExample
    {
        class MyConsoleProgram
        {
            private GraphClient Client {get;set; }
            static void Main(string[] args)
            {
            try{
                GraphClient client = new GraphClient(new Uri("http://localhost:7474/db/data"));
                client.Connect();
                Us us = new Us { Name = "We are Us" };
                NodeReference<Us> usRef = client.Create(us);
                Console.WriteLine("us node.id: {0}", usRef.Id);
                var queryUs = client.Cypher.Start("n", "node(" + usRef.Id + ")").Return<Node<Us>>("n");
                Console.WriteLine("Us node name: {0}\n", queryUs.Results.AsEnumerable<Node<Us>>().First().Data);
                AllYourBase allYourBase = new AllYourBase { Name = "We are all your base" };
                NodeReference<AllYourBase> allYourBaseRef = client.Create(allYourBase);
                Console.WriteLine("AllYourBase node.id: {0}",allYourBaseRef.Id);
                var queryAllYourBase = client.Cypher.Start("n", "node(" + allYourBaseRef.Id + ")").Return<Node<AllYourBase>>("n");
                Console.WriteLine("AllYourBase node name: {0}\n", queryAllYourBase.Results.AsEnumerable<Node<AllYourBase>>().First().Data);
                RelationshipReference areBelongToRef = client.CreateRelationship(allYourBaseRef, new AreBelongTo(usRef));
                var query = client.Cypher.Start("allyourbase", "node(" + allYourBaseRef.Id + ")").Match("allyourbase-[:ARE_BELONG_TO]->us").Return<Node<AllYourBase>>("allyourbase");
                query.ExecuteWithoutResults();
                Console.WriteLine("Result of querying for all your base that belongs to us: {0}", query.Results.AsEnumerable<Node<AllYourBase>>().First().Data.Name);
            }
            catch(Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
                Console.WriteLine("{0}", ex.InnerException);
            }
            Console.ReadKey();
        }
    }
    public class Us
    {
        public string Name {get; set;}
        public Us()
	    {
        }
    }
    public class AllYourBase
    {
        public string Name { get; set; }
        public AllYourBase()
	    {
        }
    }
    public class AreBelongTo : Relationship, IRelationshipAllowingSourceNode<AllYourBase>,
                                             IRelationshipAllowingTargetNode<Us>
    {
        public AreBelongTo(NodeReference targetNode)
            : base(targetNode)
        {}
        public const string TypeKey = "ARE_BELONG_TO";
        public override string RelationshipTypeKey
        {
            get { return TypeKey; }
        }
    }
