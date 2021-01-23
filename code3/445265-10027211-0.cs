            var sut = new BrainTeaser();
            for (int n = 1; n <= 6; n++) {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("{0} person{1}: ", n, n > 1 ? "s" : "");
                var array = sut.Solve(n).Select(x => x.ToString()).ToArray();
                sb.AppendLine(string.Join(", ", array));
                Console.WriteLine(sb.ToString());
            }
