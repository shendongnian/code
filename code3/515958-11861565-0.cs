    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Relatie
        {
            public Int32 ID_Persoon { get; set; }
            public Int32 NestorNrCliënt { get; set; }
            public Relatie(int ID_Persoon, int NestorNrCliënt)
            {
                this.ID_Persoon = ID_Persoon;
                this.NestorNrCliënt = NestorNrCliënt;
            }
        }
        class nestorDBDataContext
        {
            public List<Relatie> tbl_Relaties = new List<Relatie> {
                new Relatie(15, 27),
                new Relatie(15, 28),
                new Relatie(15, 29),
                new Relatie(15, 30),
                new Relatie(14, 30),
                new Relatie(14, 30),
                new Relatie(14, 30),
            };
        }
        class Program
        {
            public struct Client_Dto{
                public Int32 ID;
            }
            public static List<Client_Dto> GetClientByBehandelaar(string loggedInUserId)
            {
                try
                {
                    int userID = Convert.ToInt32(loggedInUserId);
                    nestorDBDataContext db = new nestorDBDataContext();
                    var result =
                        (from relaties in db.tbl_Relaties
                         where relaties.ID_Persoon == userID
                         select new Client_Dto()
                         {
                             ID = relaties.NestorNrCliënt
                         }).ToList();
                    List<Client_Dto> clienten = result;
                    return clienten;
                }
                catch (Exception e)
                {
                    throw new ArgumentException("GetClientByBehandelaar Failed " + e);
                }
            }
            static void Main(string[] args)
            {
                Console.WriteLine(GetClientByBehandelaar("15").Count());
                Console.ReadKey();
            }
        }
    }
