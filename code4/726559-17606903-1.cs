                List<CalendarEvent> myevents = new List<CalendarEvent>()
                {
                    new CalendarEvent(){date = new DateTime(2005,1,17),eventdescription = "Armaggedon",month = NameOfMonth.january},
                    new CalendarEvent(){date =  new DateTime(2005,3,20),eventdescription = "Apocalypse",month = NameOfMonth.march},
                    new CalendarEvent(){date = new DateTime(2007,5,20),eventdescription = "WorldPeace",month = NameOfMonth.may},
                    new CalendarEvent(){date = new DateTime(2009,2,20),eventdescription = "LaundryDay",month = NameOfMonth.febuary},
                    new CalendarEvent(){date = new DateTime(2009,4,15),eventdescription = "MentalHealth",month = NameOfMonth.april},
                    new CalendarEvent(){date = new DateTime(2009,6,10),eventdescription = "ProgrammingInC#",month = NameOfMonth.june},
                    new CalendarEvent(){date = new DateTime(2009,6,12),eventdescription = "EraseAllYourWork?",month = NameOfMonth.june},
                    new CalendarEvent(){date = new DateTime(2010,10,20),eventdescription = "SomeVeryNiceEvent",month = NameOfMonth.october},
                    new CalendarEvent(){date = new DateTime(2010,8,21),eventdescription = "WellAnotherEvent",month = NameOfMonth.august}
                };
                var result = myevents2.GroupBy(d => d.date.Year)
                          .Select(g => new { Year = g.Key, data = g.OrderByDescending(k => k.date.Month).ThenByDescending(day => day.date.Day) })
                          .ToList();
    
                foreach (var item in result)
                {
                    Console.WriteLine("Events on ***" + item.Year + "***");
                    foreach (var subitems in item.data)
                    {  
                        Console.WriteLine(subitems.month.ToString());
                        Console.WriteLine("On day " + subitems.date.Day + " - " + subitems.eventdescription);
                    }
                }
