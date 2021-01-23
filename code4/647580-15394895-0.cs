     protected void Page_Load(object sender, EventArgs e)
            {
                foreach (string line in File.ReadLines(@"C:\Users\Matt\Desktop\AirportCodes2.txt"))
                {
                    if (line.Contains("Chicago"))
                    {
                        Response.Write(line);
                    }
                }
            }
