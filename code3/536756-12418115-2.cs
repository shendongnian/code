            var r = new Random();
            var n = int.Parse(this.textBox1.Text);
            var y =
                Enumerable
                    .Range(0, n)
                    .Select(x => r.Next(20) + 1)
                    .ToArray();
            var sum = y.Sum();
            var avg = (double)sum / (double)n;
            var frequency = y.ToLookup(x => x);
            textBox2.Text = String.Join(Environment.NewLine, new[]
            {
                "Results",
                String.Format("{0} {1}", sum, avg),
            }.Concat(Enumerable
                .Range(1, 20)
                .Select(x => String.Format("{0} ({1}x)", x, frequency[x].Count()))));
