                foreach (var visit in listOfVisits)
                {
                    var impVisit = visit as ImpatientVisit;
                    if (impVisit != null)
                    {
                        Console.WriteLine(impVisit.ImpatientProperty + " "+ impVisit.VisitName);
                    }
                    else
                    {
                        Console.WriteLine(visit.VisitName);
                    }
                }  
