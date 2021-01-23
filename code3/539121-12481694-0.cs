    string par = Regex.Match(line, @"(?<=\()(([^)]*))(?=\))").Value;
                    try
                    {
                        double par2 = double.Parse(par);
                        res += par2;
                    }
                    catch
                    {
                    }
