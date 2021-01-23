            var points = pathsDocument.Descendants("Point");
            foreach (var point in points)
            {
                var statements = point.Elements("Statement").Select(x => x.Element("StatementString").Value );
                Console.WriteLine(string.Join(" ", statements));
            }
