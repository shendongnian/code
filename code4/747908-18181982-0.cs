            if (blueBallPosition[0] < 360 && greenBallPosition[0] < 360)
            {
                var paulse = blueBallPosition.Select((b, idx) =>
                    new { Blue = b, Green = greenBallPosition[idx] })
                 .Skip(1).All(x => x.Blue > 360 && x.Green > 360);
            }
