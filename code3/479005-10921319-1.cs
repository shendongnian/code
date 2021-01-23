            double[] test = { 8.99999999, -4, 34.567, -234.2354, 2.34, 500.8 };
            using (var sw = new FileStream(@"c:\temp\test.txt", FileMode.Create))
            {
                using (var bw = new BinaryWriter(sw))
                {
                    const byte semicol = 59, minus = 45, dec = 46, b0 = 48;
                    Action<double> write = d =>
                    {
                        if (d == 0)
                            bw.Write(b0);
                        else
                        {
                            if (d < 0)
                            {
                                bw.Write(minus);
                                d = -d;
                            }
                            double m = Math.Pow(10d, Math.Truncate(Math.Log10(d)));
                            while(true)
                            {
                                var r = ((decimal)(d / m) % 10); //decimal because of floating point errors
                                if (r == 0) break;
                                if (m == 0.1)
                                    bw.Write(dec); //decimal point
                                bw.Write((byte)(48 + r));         
                                m /= 10d;
                            }
                        }
                        bw.Write(semicol);
                    };
                    foreach (var d in test)
                        write(d);
                }
            }
