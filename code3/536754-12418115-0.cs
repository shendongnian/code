            var r = new Random();
            var n = int.Parse(this.textBox1.Text);
            var y =
                Enumerable
                    .Range(0, n)
                    .Select(x => r.Next(20) + 1)
                    .ToArray();
            var sum = y.Sum();
            var avg = (double)sum / (double)n;
            var frequency =
                y
                    .GroupBy(x => x)
                    .ToDictionary(x => x.Key, x => x.Count());
            textBox2.Text = String.Join(Environment.NewLine, new[]
            {
                "Results",
                String.Format("{0} {1}", sum, avg),
            }.Concat(frequency
                .OrderBy(x => x.Key)
                .Select(x => String.Format("{0} ({1}x)", x.Key, x.Value))));
