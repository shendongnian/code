    var pLines = new Polyline();
    pLines.Points.Add(new Point(10, 140));
    pLines.Points.Add(new Point(270, 140));
    pLines.Points.Add(new Point(270, 220));
    pLines.Points.Add(new Point(255, 220));
    pLines.Points.Add(new Point(230, 175));
    pLines.Points.Add(new Point(205, 220));
    string asXaml = XamlWriter.Save(pLines);
    //<Polyline Points="10,140 270,140 270,220 255,220 230,175 205,220" xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" />
