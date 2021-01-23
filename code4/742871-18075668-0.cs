                Console.WriteLine("Enter the Date Scheduled For the Meeting:");
                string Date = Console.ReadLine();
                DateTime Test;
                if(DateTime.TryParseExact(Date, "MM/dd/yyyy", null, DateTimeStyles.None, out Test) == true)
                {
                        Console.WriteLine("Date is in the correct Format");
                }
                else
                {
                         Console.Write("Date Not OK");
                         return;
                }
