    public virtual bool hasArrivalDate(string date)
            {
                try
                {
                    DateTime d = DateTime.ParseExact(date,"dd/MM/yyyy",CultureInfo.InvariantCulture);
                    Console.WriteLine("Comparing " + d.ToString("dd/MM/yyyy") + " with " + dateSignedIn.ToString("dd/MM/yyyy") + " = " + dateSignedIn.ToString("dd/MM/yyyy").Equals(d.ToString("dd/MM/yyyy")));
                    return dateSignedIn.ToString().Equals(d.ToString());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.ToString());
                    Console.Write(e.StackTrace);
                    return false;
                }
            }
