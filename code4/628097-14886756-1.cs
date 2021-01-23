    var player_query = from p in xDoc.Descendants("person")
        select new Player
        {
            FirstName = p.Element("fname").AsString(),
            LastName = p.Element("lname").AsString()
            Leap1 = p.Descendants("try1").FirstOrDefault().AsInt(),
            Leap2 = p.Descendants("try2").FirstOrDefault().AsInt(),
            Leap3 = p.Descendants("try3").FirstOrDefault().AsInt()
        };
