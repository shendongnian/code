    var r = File.ReadAllLines(path)
                .Select(line => line.Split(' '))
                .Select(arr => new
                    {
                        Column0 = Int32.Parse(arr[0]),
                        Column1 = Int32.Parse(arr[1])
                        // etc
                    })
                .ToArray();
