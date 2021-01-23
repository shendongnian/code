    select new NewGamesClass
               {
                   GameID = (string)query.Element("ID"),
                   GameTitle = (string)query.Element("Title"),
                   GameDescription = (string)query.Element("Description"),
                   GameGuide = (string)query.Element("Guide")
                }
