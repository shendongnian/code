    string filePath ="C:\wherethefileIs";
    double targetPosition = 18.10;
   
    var query = from line in File.ReadAllLines(filePath)
                        let dataLine = line.Split(new[] {' '})
                        select new
                            {
                                Frame = Int32.Parse(dataLine[0]),
                                Position = Double.Parse(dataLine[1])
                            };
    var nearestFrame = query.OrderBy(e => Math.Abs(e.Position - targetPosition)).Select(e=>e.Frame).FirstOrDefault();
