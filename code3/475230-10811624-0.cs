            var pathgeo = new PathGeometry();
            pathgeo.AddGeometry(new PathGeometry(new PathFigureCollection() { new PathFigure(new Point(10, 50), new List<PathSegment>() { new LineSegment(new Point(200, 70), true) }, false) }));
            // Save
            var s = XamlWriter.Save(pathgeo);
            byte[] byteArray = Encoding.ASCII.GetBytes(s);
            var stream = new MemoryStream(byteArray);
            // Load
            var ob = XamlReader.Load(stream);
            // test beeing a System.Windows.Shapes.Path
            test.Data = ob as PathGeometry;
